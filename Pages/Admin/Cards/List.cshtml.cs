using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin
{
    public class ListModel : PageModel
    {
        private readonly ICardService _cardService;
        private readonly IGradeCompanyService _gradeCompanyService;
        private readonly ILocationService _locationService;
        private readonly IPlayerService _playerService;
        private readonly ISetService _setService;
        private readonly ISportService _sportService;
        private readonly ITeamService _teamService;
        private readonly IYearService _yearService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="cardService">The card service.</param>
        public ListModel(ICardService cardService,
            IGradeCompanyService gradeCompanyService,
            ILocationService locationService,
            IPlayerService playerService,
            ISetService setService,
            ISportService sportService,
            ITeamService teamService,
            IYearService yearService)
        {
            _cardService = cardService;
            _gradeCompanyService = gradeCompanyService;
            _locationService = locationService;
            _playerService = playerService;
            _setService = setService;
            _sportService = sportService;
            _teamService = teamService;
            _yearService = yearService;
        }

        /// <summary>
        /// Gets or sets the card view models.
        /// </summary>
        /// <value>
        /// The card view models.
        /// </value>
        [BindProperty]
        public IEnumerable<CardViewModel> CardViewModels { get; set; }


        /// <summary>
        /// Gets or sets the card view model.
        /// </summary>
        /// <value>
        /// The card view model.
        /// </value>
         [BindProperty]
        public CardViewModel CardViewModel { get; set; }

        /// <summary>
        /// Gets or sets the player view models.
        /// </summary>
        /// <value>
        /// The player view models.
        /// </value>
        [BindProperty]
        public IEnumerable<PlayerViewModel> PlayerViewModels { get; set; }

        /// <summary>
        /// Gets or sets the team view models.
        /// </summary>
        /// <value>
        /// The team view models.
        /// </value>
        [BindProperty]
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }

        /// <summary>
        /// Gets or sets the sport view models.
        /// </summary>
        /// <value>
        /// The sport view models.
        /// </value>
        [BindProperty]
        public IEnumerable<SportViewModel> SportViewModels { get; set; }

        /// <summary>
        /// Gets or sets the year view models.
        /// </summary>
        /// <value>
        /// The year view models.
        /// </value>
        [BindProperty]
        public IEnumerable<YearViewModel> YearViewModels { get; set; }

        /// <summary>
        /// Gets or sets the set view models.
        /// </summary>
        /// <value>
        /// The set view models.
        /// </value>
        [BindProperty]
        public IEnumerable<SetViewModel> SetViewModels { get; set; }

        /// <summary>
        /// Gets or sets the grade company view models.
        /// </summary>
        /// <value>
        /// The grade company view models.
        /// </value>
        [BindProperty]
        public IEnumerable<GradeCompanyViewModel> GradeCompanyViewModels { get; set; }

        /// <summary>
        /// Gets or sets the location view models.
        /// </summary>
        /// <value>
        /// The location view models.
        /// </value>
        [BindProperty]
        public IEnumerable<LocationViewModel> LocationViewModels { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int cardId, CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            if (cardId > 0)
            {
                ViewData["Success"] = "Update your card.";
                var model = CardViewModels.FirstOrDefault(x => x.CardId == cardId);
                if (model == null)
                {
                    return BadRequest();
                }
                CardViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a card.";
                CardViewModel = new CardViewModel();
            }

            return Page();
        }

        private async Task FillModelsAsync(CancellationToken cancellationToken)
        {
            CardViewModels = await _cardService.GetCardsAsync(cancellationToken).ConfigureAwait(false);
            PlayerViewModels = await _playerService.GetPlayersAsync(cancellationToken).ConfigureAwait(false);
            TeamViewModels = await _teamService.GetTeamsAsync(cancellationToken).ConfigureAwait(false);
            SportViewModels = await _sportService.GetSportsAsync(cancellationToken).ConfigureAwait(false);
            YearViewModels = await _yearService.GetYearsAsync(cancellationToken).ConfigureAwait(false);
            SetViewModels = await _setService.GetSetsAsync(cancellationToken).ConfigureAwait(false);
            GradeCompanyViewModels = await _gradeCompanyService.GetGradeCompaniesAsync(cancellationToken).ConfigureAwait(false);
            LocationViewModels = await _locationService.GetLocationsAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
