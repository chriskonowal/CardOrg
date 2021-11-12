using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Landing
{
    /// <summary>
    /// The index model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class IndexModel : PageModel
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
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="cardService">The card service.</param>
        /// <param name="gradeCompanyService">The grade company service.</param>
        /// <param name="locationService">The location service.</param>
        /// <param name="playerService">The player service.</param>
        /// <param name="setService">The set service.</param>
        /// <param name="sportService">The sport service.</param>
        /// <param name="teamService">The team service.</param>
        /// <param name="yearService">The year service.</param>
        public IndexModel(ICardService cardService,
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
        /// Gets or sets the search view model.
        /// </summary>
        /// <value>
        /// The search view model.
        /// </value>
        [BindProperty]
        public SearchViewModel SearchViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }

        /// <summary>
        /// Called when [post search asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostSearchAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            if (SearchViewModel.IsAutograph)
            {
                CardViewModels = CardViewModels.Where(x => x.IsAutograph);
            }
            if (SearchViewModel.IsGameWornJersey)
            {
                CardViewModels = CardViewModels.Where(x => x.IsGameWornJersey);
            }
            if (SearchViewModel.IsGraded)
            {
                CardViewModels = CardViewModels.Where(x => x.IsGraded);
            }
            if (SearchViewModel.IsOnCardAutograph)
            {
                CardViewModels = CardViewModels.Where(x => x.IsOnCardAutograph);
            }
            if (SearchViewModel.IsPatch)
            {
                CardViewModels = CardViewModels.Where(x => x.IsPatch);
            }
            if (SearchViewModel.IsRookie)
            {
                CardViewModels = CardViewModels.Where(x => x.IsRookie);
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.PlayerIds))
            {
                CardViewModels = CardViewModels.Where(x => x.Players.Any(y =>SearchViewModel.PlayerIds.Contains(y.PlayerId.ToString())));
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.TeamIds))
            {
                CardViewModels = CardViewModels.Where(x => x.Teams.Any(y => SearchViewModel.TeamIds.Contains(y.TeamId.ToString())));
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.SportIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchViewModel.SportIds.Contains(x.SportId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.YearIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchViewModel.YearIds.Contains(x.YearId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.SetIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchViewModel.SetIds.Contains(x.SetId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.GradeCompanyIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchViewModel.GradeCompanyIds.Contains(x.GradeCompanyId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchViewModel.LocationIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchViewModel.LocationIds.Contains(x.LocationId.ToString()));
            }
            return Page();
        }

        public async Task FillModelsAsync(CancellationToken cancellationToken)
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
