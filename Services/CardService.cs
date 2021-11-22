using CardOrg.Contexts;
using CardOrg.Converters;
using CardOrg.Entities;
using CardOrg.Extensions;
using CardOrg.Interfaces.Repositories;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Services
{
    /// <summary>
    /// The card service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.ISaveCardService" />
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IGradeCompanyService _gradeCompanyService;
        private readonly ILocationService _locationService;
        private readonly IPlayerCardRepository _playerCardRepository; 
        private readonly IPlayerService _playerService;
        private readonly ISetService _setService;
        private readonly ISportService _sportService;
        private readonly ITeamCardRepository _teamCardRepository;
        private readonly ITeamService _teamService;
        private readonly IYearService _yearService;

        private IWebHostEnvironment _hostingEnvironment ;
        private const string AVATAR_IMAGE_NAME = "card-avatar.jpg";

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCardService"/> class.
        /// </summary>
        /// <param name="cardRepository">The card repository.</param>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        public CardService(ICardRepository cardRepository, 
            IGradeCompanyService gradeCompanyService,
            ILocationService locationService,
            IPlayerCardRepository playerCardRepository,
            IPlayerService playerService,
            ISetService setService,
            ISportService sportService,
            ITeamCardRepository teamCardRepository,
            ITeamService teamService,
            IYearService yearService,
            IWebHostEnvironment hostingEnvironment)
        {
            _cardRepository = cardRepository;
            _gradeCompanyService = gradeCompanyService;
            _locationService = locationService;
            _playerCardRepository = playerCardRepository;
            _playerService = playerService;
            _setService = setService;
            _sportService = sportService;
            _teamCardRepository = teamCardRepository;
            _teamService = teamService;
            _yearService = yearService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CardViewModel>> GetCardsAsync(CancellationToken cancellationToken)
        {
            var cardEntities = await _cardRepository.GetCardsAsync(cancellationToken).ConfigureAwait(false);
            return await GetCardViewModelsAsync(cardEntities, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CardViewModel>> GetTop10NewestCardsAsync(CancellationToken cancellationToken)
        {
            var cardEntities = await _cardRepository.GetTop10NewestCardsAsync(cancellationToken).ConfigureAwait(false);
            return await GetCardViewModelsAsync(cardEntities, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<bool> SaveCardAsync(CardViewModel model, CancellationToken cancellationToken)
        {
            var entity = CardViewModelConverter.Convert(model);

            var savePictures = await SavePictureAsync(model, cancellationToken);
            entity.FrontCardMainImagePath = savePictures.FrontMainFileName;
            entity.FrontCardThumbnailImagePath = savePictures.FrontThumbnailFileName;
            entity.BackCardMainImagePath = savePictures.BackMainFileName;
            entity.BackCardThumbnailImagePath = savePictures.BackThumbnailFileName;

            if (entity.CardId > 0)
            {
                entity = await _cardRepository.UpdateCardAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                entity = await _cardRepository.InsertCardAsync(entity, cancellationToken).ConfigureAwait(false);
            }

            await _playerCardRepository.DeletePlayerCardAsync(entity.CardId, cancellationToken).ConfigureAwait(false);
            if (model.PlayerIds.Length > 0)
            {
                foreach (var playerId in model.PlayerIds.Split(','))
                {
                    if (Int32.TryParse(playerId, out int id))
                    {
                        await _playerCardRepository.InsertPlayerCardAsync(entity.CardId, id, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            await _teamCardRepository.DeleteTeamCardAsync(entity.CardId, cancellationToken).ConfigureAwait(false);
            if (model.TeamIds.Length > 0)
            {
                foreach (var teamId in model.TeamIds.Split(','))
                {
                    if (Int32.TryParse(teamId, out int id))
                    {
                        await _teamCardRepository.InsertTeamCardAsync(entity.CardId, id, cancellationToken).ConfigureAwait(false);
                    }
                }
            }


            return true;
        }

        /// <inheritdoc/>
        public async Task<int> DeleteCardAsync(int cardId, CancellationToken cancellationToken)
        {
            return await _cardRepository.DeleteCardAsync(cardId, cancellationToken).ConfigureAwait(false);
        }

        private async Task<FileContext> SavePictureAsync(CardViewModel model, CancellationToken cancellationToken)
        {
            var fileContext = new FileContext();
            if (model.FrontUpload == null &&
                String.IsNullOrWhiteSpace(model.FrontCardMainImagePath) &&
                String.IsNullOrWhiteSpace(model.FrontCardThumbnailImagePath))
            {
                fileContext.FrontMainFileName = AVATAR_IMAGE_NAME;
                fileContext.FrontThumbnailFileName = AVATAR_IMAGE_NAME;
            }
            else if (model.FrontUpload == null &&
                !String.IsNullOrWhiteSpace(model.FrontCardMainImagePath) &&
                !String.IsNullOrWhiteSpace(model.FrontCardThumbnailImagePath))
            {
                fileContext.FrontMainFileName = model.FrontCardMainImagePath;
                fileContext.FrontThumbnailFileName = model.FrontCardThumbnailImagePath;
            }
            else
            {
                var fileName = Path.GetFileNameWithoutExtension($"{model.CardDescription}{model.CardNumber}_front").ReturnAlphaNumericCharacters();
                fileName = fileName.StripInvalidFileNameCharacters();
                var extension = Path.GetExtension(model.FrontUpload.FileName);
                if (!String.IsNullOrWhiteSpace(fileName))
                {
                    var file = $"{_hostingEnvironment.WebRootPath}\\Uploads\\{fileName}{extension}";
                    using (var input = model.FrontUpload.OpenReadStream())
                    {
                        using (var output = new MemoryStream())
                        {
                            using (var image = new MagickImage(input))
                            {
                                input.Position = 0;
                                await image.WriteAsync(file);
                            }
                        }
                    }

                    file = $"{_hostingEnvironment.WebRootPath}\\Uploads\\{fileName}_thumb{extension}";
                    using (var input = model.FrontUpload.OpenReadStream())
                    {
                        using (var output = new MemoryStream())
                        {
                            using (var image = new MagickImage(input))
                            {
                                image.Resize(120, 213);
                                input.Position = 0;
                                await image.WriteAsync(file);
                            }
                        }
                    }

                    fileContext.FrontMainFileName = $"{fileName}{extension}";
                    fileContext.FrontThumbnailFileName = $"{fileName}_thumb{extension}";
                }
                else
                {
                    fileContext.FrontMainFileName = AVATAR_IMAGE_NAME;
                    fileContext.FrontThumbnailFileName = AVATAR_IMAGE_NAME;
                }
            }

            if (model.BackUpload == null &&
                String.IsNullOrWhiteSpace(model.BackCardMainImagePath) &&
                String.IsNullOrWhiteSpace(model.BackCardThumbnailImagePath))
            {
                fileContext.BackMainFileName = AVATAR_IMAGE_NAME;
                fileContext.BackThumbnailFileName = AVATAR_IMAGE_NAME;
                return fileContext;
            }
            else if (model.FrontUpload == null &&
               !String.IsNullOrWhiteSpace(model.BackCardMainImagePath) &&
               !String.IsNullOrWhiteSpace(model.BackCardThumbnailImagePath))
            {
                fileContext.BackMainFileName = model.BackCardMainImagePath;
                fileContext.BackThumbnailFileName = model.BackCardThumbnailImagePath;
            }
            else
            {
                var fileName = Path.GetFileNameWithoutExtension($"{model.CardDescription}{model.CardNumber}_back").ReturnAlphaNumericCharacters();
                fileName = fileName.StripInvalidFileNameCharacters();
                var extension = Path.GetExtension(model.BackUpload.FileName);
                if (!String.IsNullOrWhiteSpace(fileName))
                {
                    var file = $"{_hostingEnvironment.WebRootPath}\\Uploads\\{fileName}{extension}";
                    using (var input = model.FrontUpload.OpenReadStream())
                    {
                        using (var output = new MemoryStream())
                        {
                            using (var image = new MagickImage(input))
                            {
                                input.Position = 0;
                                await image.WriteAsync(file);
                            }
                        }
                    }

                    file = $"{_hostingEnvironment.WebRootPath}\\Uploads\\{fileName}_thumb{extension}";
                    using (var input = model.FrontUpload.OpenReadStream())
                    {
                        using (var output = new MemoryStream())
                        {
                            using (var image = new MagickImage(input))
                            {
                                image.Resize(120, 213);
                                input.Position = 0;
                                await image.WriteAsync(file);
                            }
                        }
                    }

                    fileContext.BackMainFileName = $"{fileName}{extension}";
                    fileContext.BackThumbnailFileName = $"{fileName}_thumb{extension}";
                }
                else
                {
                    fileContext.BackMainFileName = AVATAR_IMAGE_NAME;
                    fileContext.BackThumbnailFileName = AVATAR_IMAGE_NAME;
                }
            }

            return fileContext;
        }

        private async Task<IEnumerable<CardViewModel>> GetCardViewModelsAsync(IEnumerable<CardEntity> entities, CancellationToken cancellationToken)
        {
            var cardIds = entities.Select(x => x.CardId);

            var gradeCompanyIds = new List<int>();
            var locationIds = new List<int>();
            var setIds = new List<int>();
            var sportIds = new List<int>();
            var yearIds = new List<int>();

            foreach (var cardEntity in entities)
            {
                if (!gradeCompanyIds.Contains(cardEntity.GradeCompanyId))
                {
                    gradeCompanyIds.Add(cardEntity.GradeCompanyId);
                }
                if (!locationIds.Contains(cardEntity.LocationId))
                {
                    locationIds.Add(cardEntity.LocationId);
                }
                if (!setIds.Contains(cardEntity.SetId))
                {
                    setIds.Add(cardEntity.SetId);
                }
                if (!sportIds.Contains(cardEntity.SportId))
                {
                    sportIds.Add(cardEntity.SportId);
                }
                if (!yearIds.Contains(cardEntity.YearId))
                {
                    yearIds.Add(cardEntity.YearId);
                }
            }

            var gradeCompanyModels = await _gradeCompanyService.GetByIdsAsync(gradeCompanyIds, cancellationToken).ConfigureAwait(false);
            var locationModels = await _locationService.GetByIdsAsync(locationIds, cancellationToken).ConfigureAwait(false);
            var playerCardEntities = await _playerCardRepository.GetPlayerCardsAsync(cardIds, cancellationToken).ConfigureAwait(false);
            var playerModels = await _playerService.GetByIdsAsync(playerCardEntities.Select(x => x.PlayerId), cancellationToken).ConfigureAwait(false);
            var setModels = await _setService.GetByIdsAsync(setIds, cancellationToken).ConfigureAwait(false);
            var sportEntities = await _sportService.GetByIdsAsync(sportIds, cancellationToken).ConfigureAwait(false);
            var teamCardEntities = await _teamCardRepository.GetTeamCardsAsync(cardIds, cancellationToken).ConfigureAwait(false);
            var teamModels = await _teamService.GetByIdsAsync(teamCardEntities.Select(x => x.TeamId), cancellationToken).ConfigureAwait(false);
            var yearModels = await _yearService.GetByIdsAsync(yearIds, cancellationToken).ConfigureAwait(false);

            var models = new List<CardViewModel>();
            foreach (var cardEntity in entities)
            {
                var model = CardViewModelConverter.Convert(cardEntity);
                model.GradeCompany = gradeCompanyModels.FirstOrDefault(x => x.GradeCompanyId == cardEntity.GradeCompanyId);
                model.Location = locationModels.FirstOrDefault(x => x.LocationId == cardEntity.LocationId);

                var playerCards = playerCardEntities.Where(c => c.CardId == cardEntity.CardId).Select(p => p.PlayerId);
                model.Players = playerModels.Where(x => playerCards.Contains(x.PlayerId));
                model.PlayerIds = String.Join(",", model.Players.Select(x => x.PlayerId));

                model.Set = setModels.FirstOrDefault(x => x.SetId == cardEntity.SetId);
                model.Sport = sportEntities.FirstOrDefault(x => x.SportId == cardEntity.SportId);

                var teamCards = teamCardEntities.Where(c => c.CardId == cardEntity.CardId).Select(t => t.TeamId);
                model.Teams = teamModels.Where(x => teamCards.Contains(x.TeamId));
                model.TeamIds = String.Join(",", model.Teams.Select(x => x.TeamId));

                model.Year = yearModels.FirstOrDefault(x => x.YearId == cardEntity.YearId);
                models.Add(model);
            }

            return models;
        }
    }
}
