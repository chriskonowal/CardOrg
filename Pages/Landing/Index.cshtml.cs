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
        private readonly ISearchSortService _searchSortService;
        private readonly ISetService _setService;
        private readonly ISportService _sportService;
        private readonly ITeamService _teamService;
        private readonly IYearService _yearService;

        private const string AVATAR_IMAGE_NAME = "card-avatar.jpg";

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
            ISearchSortService searchSortService,
            ISetService setService,
            ISportService sportService,
            ITeamService teamService,
            IYearService yearService)
        {
            _cardService = cardService;
            _gradeCompanyService = gradeCompanyService;
            _locationService = locationService;
            _playerService = playerService;
            _searchSortService = searchSortService;
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
        /// Gets or sets the search sort view model.
        /// </summary>
        /// <value>
        /// The search view model.
        /// </value>
        [BindProperty]
        public SearchSortViewModel SearchSortViewModel { get; set; }

        [BindProperty]
        public IEnumerable<SearchSortViewModel> SearchSortViewModels { get; set; }

        public IEnumerable<SortViewModel> SortViewModels { get; set; } = new List<SortViewModel>
        {   new SortViewModel(0, "None"),
            new SortViewModel(1, "Ascending"),
            new SortViewModel(2, "Descending")
        };

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            SearchSortViewModel = new SearchSortViewModel();
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
            if (!ModelState.IsValid)
            {
                ViewData["SearchSortError"] = true;
                SearchSortViewModel = new SearchSortViewModel();
                return Page();
            }
            else
            {
                ViewData["SearchSortError"] = false;
            }
            
            FilterResults();
            return Page();
        }

        /// <summary>
        /// Called when [post sort asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostSortAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            if (!ModelState.IsValid)
            {
                ViewData["SearchSortError"] = true;
                SearchSortViewModel = new SearchSortViewModel();
                return Page();
            }
            else
            {
                ViewData["SearchSortError"] = false;
            }
            FilterResults();
            return Page();
        }

        /// <summary>
        /// Called when [post clear asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostClearAsync(CancellationToken cancellationToken)
        {
            ModelState.Clear();
            SearchSortViewModel = new SearchSortViewModel();
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }

        public async Task<IActionResult> OnPostSaveSearchSortAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            if (!ModelState.IsValid)
            {
                ViewData["SearchSortError"] = true;
                SearchSortViewModel = new SearchSortViewModel();
                return Page();
            }
            else
            {
                ViewData["SearchSortError"] = false;
            }

            await _searchSortService.SaveSearchSortAsync(SearchSortViewModel, cancellationToken).ConfigureAwait(false);
            SearchSortViewModel = new SearchSortViewModel();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteSearchSortAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
  
            await _searchSortService.DeleteSearchSortAsync(SearchSortViewModel.SearchSortId, cancellationToken).ConfigureAwait(false);
            SearchSortViewModel = new SearchSortViewModel();

            return Page();
        }

        public async Task<IActionResult> OnPostLoadSearchSortAsync(CancellationToken cancellationToken)
        {
            await FillModelsAsync(cancellationToken).ConfigureAwait(false);
            SearchSortViewModel = await _searchSortService.GetSearchSortByIdAsync(SearchSortViewModel.SearchSortId, cancellationToken).ConfigureAwait(false);
            FilterResults();

            return Page();
        }

        public void FilterResults()
        {
            if (SearchSortViewModel.IsAutograph)
            {
                CardViewModels = CardViewModels.Where(x => x.IsAutograph);
            }
            if (SearchSortViewModel.IsGameWornJersey)
            {
                CardViewModels = CardViewModels.Where(x => x.IsGameWornJersey);
            }
            if (SearchSortViewModel.IsGraded)
            {
                CardViewModels = CardViewModels.Where(x => x.IsGraded);
            }
            if (SearchSortViewModel.IsOnCardAutograph)
            {
                CardViewModels = CardViewModels.Where(x => x.IsOnCardAutograph);
            }
            if (SearchSortViewModel.IsPatch)
            {
                CardViewModels = CardViewModels.Where(x => x.IsPatch);
            }
            if (SearchSortViewModel.IsRookie)
            {
                CardViewModels = CardViewModels.Where(x => x.IsRookie);
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.PlayerIds))
            {
                CardViewModels = CardViewModels.Where(x => x.Players.Any(y => SearchSortViewModel.PlayerIds.Contains(y.PlayerId.ToString())));
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.TeamIds))
            {
                CardViewModels = CardViewModels.Where(x => x.Teams.Any(y => SearchSortViewModel.TeamIds.Contains(y.TeamId.ToString())));
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.SportIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchSortViewModel.SportIds.Contains(x.SportId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.YearIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchSortViewModel.YearIds.Contains(x.YearId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.SetIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchSortViewModel.SetIds.Contains(x.SetId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.GradeCompanyIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchSortViewModel.GradeCompanyIds.Contains(x.GradeCompanyId.ToString()));
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.LocationIds))
            {
                CardViewModels = CardViewModels.Where(x => SearchSortViewModel.LocationIds.Contains(x.LocationId.ToString()));
            }
            if (SearchSortViewModel.LowestBecketPriceLow >= 0 && SearchSortViewModel.LowestBecketPriceHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.LowestBeckettPrice >= SearchSortViewModel.LowestBecketPriceLow && x.LowestBeckettPrice <= SearchSortViewModel.LowestBecketPriceHigh);
            }
            if (SearchSortViewModel.HighestBecketPriceLow >= 0 && SearchSortViewModel.HighestBecketPriceHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.HighestBeckettPrice >= SearchSortViewModel.HighestBecketPriceLow && x.HighestBeckettPrice <= SearchSortViewModel.HighestBecketPriceHigh);
            }
            if (SearchSortViewModel.LowestCOMCPriceLow >= 0 && SearchSortViewModel.LowestCOMCPriceHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.LowestCOMCPrice >= SearchSortViewModel.LowestCOMCPriceLow && x.LowestCOMCPrice <= SearchSortViewModel.LowestCOMCPriceHigh);
            }
            if (SearchSortViewModel.EbayPriceLow >= 0 && SearchSortViewModel.EbayPriceHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.EbayPrice >= SearchSortViewModel.EbayPriceLow && x.EbayPrice <= SearchSortViewModel.EbayPriceHigh);
            }
            if (SearchSortViewModel.PricePaidLow >= 0 && SearchSortViewModel.PricePaidHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.PricePaid >= SearchSortViewModel.PricePaidLow && x.PricePaid <= SearchSortViewModel.PricePaidHigh);
            }
            if (SearchSortViewModel.GradeLow >= 0 && SearchSortViewModel.GradeHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.Grade >= SearchSortViewModel.GradeLow && x.Grade <= SearchSortViewModel.GradeHigh);
            }
            if (SearchSortViewModel.CopiesLow >= 0 && SearchSortViewModel.CopiesHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.Copies >= SearchSortViewModel.CopiesLow && x.Copies <= SearchSortViewModel.CopiesHigh);
            }
            if (SearchSortViewModel.SerialNumberLow >= 0 && SearchSortViewModel.SerialNumberHigh > 0)
            {
                CardViewModels = CardViewModels.Where(x => x.SerialNumber >= SearchSortViewModel.SerialNumberLow && x.SerialNumber <= SearchSortViewModel.SerialNumberHigh);
            }
            if (SearchSortViewModel.HasImage)
            {
                CardViewModels = CardViewModels.Where(x => x.FrontCardMainImagePath != AVATAR_IMAGE_NAME && x.BackCardMainImagePath != AVATAR_IMAGE_NAME);
            }
            if (!String.IsNullOrWhiteSpace(SearchSortViewModel.CardDescription))
            {
                CardViewModels = CardViewModels.Where(x => x.CardDescription.ToLower().Contains(SearchSortViewModel.CardDescription.ToLower()));
            }
            if (SearchSortViewModel.TimeStampStart.GetValueOrDefault() != DateTime.MinValue && SearchSortViewModel.TimeStampEnd.GetValueOrDefault() != DateTime.MinValue)
            {
                CardViewModels = CardViewModels.Where(x => x.TimeStamp >= SearchSortViewModel.TimeStampStart && x.TimeStamp <= SearchSortViewModel.TimeStampEnd);
            }
            if (SearchSortViewModel.PlayerNameSort != 0)
            {
                if (SearchSortViewModel.PlayerNameSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Players.OrderBy(y => y.LastName).ThenBy(y => y.FirstName).FirstOrDefault().LastName).ThenBy(x => x.Players.OrderBy(y => y.LastName).ThenBy(y => y.FirstName).FirstOrDefault().FirstName);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Players.OrderByDescending(y => y.LastName).ThenByDescending(y => y.FirstName).FirstOrDefault().LastName).ThenByDescending(x => x.Players.OrderBy(y => y.LastName).ThenByDescending(y => y.FirstName).FirstOrDefault().FirstName);
                }
            }
            if (SearchSortViewModel.TeamSort != 0)
            {
                if (SearchSortViewModel.TeamSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Teams.OrderBy(y => y.City).ThenBy(y => y.Name).FirstOrDefault().City).ThenBy(x => x.Teams.OrderBy(y => y.City).ThenBy(y => y.Name).FirstOrDefault().Name);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Teams.OrderByDescending(y => y.City).ThenByDescending(y => y.Name).FirstOrDefault().City).ThenByDescending(x => x.Teams.OrderBy(y => y.City).ThenByDescending(y => y.Name).FirstOrDefault().Name);
                }
            }
            if (SearchSortViewModel.CardDescriptionSort != 0)
            {
                if (SearchSortViewModel.CardDescriptionSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.CardDescription);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.CardDescription);
                }
            }
            if (SearchSortViewModel.LowestBeckettPriceSort != 0)
            {
                if (SearchSortViewModel.LowestBeckettPriceSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.LowestBeckettPrice);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.LowestBeckettPrice);
                }
            }
            if (SearchSortViewModel.HighestBeckettPriceSort != 0)
            {
                if (SearchSortViewModel.HighestBeckettPriceSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.HighestBeckettPrice);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.HighestBeckettPrice);
                }
            }
            if (SearchSortViewModel.LowestCOMCPriceSort != 0)
            {
                if (SearchSortViewModel.LowestCOMCPriceSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.LowestCOMCPrice);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.LowestCOMCPrice);
                }
            }
            if (SearchSortViewModel.EbayPriceSort != 0)
            {
                if (SearchSortViewModel.EbayPriceSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.EbayPrice);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.EbayPrice);
                }
            }
            if (SearchSortViewModel.HasImageSort != 0)
            {
                if (SearchSortViewModel.HasImageSort == 1)
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.FrontCardMainImagePath != AVATAR_IMAGE_NAME);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.FrontCardMainImagePath != AVATAR_IMAGE_NAME);
                }
            }
            if (SearchSortViewModel.IsGradedSort != 0)
            {
                if (SearchSortViewModel.IsGradedSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.IsGraded);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.IsGraded);
                }
            }
            if (SearchSortViewModel.IsRookieSort != 0)
            {
                if (SearchSortViewModel.IsRookieSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.IsRookie);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.IsRookie);
                }
            }
            if (SearchSortViewModel.IsAutographSort != 0)
            {
                if (SearchSortViewModel.IsAutographSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.IsAutograph);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.IsAutograph);
                }
            }
            if (SearchSortViewModel.IsOnCardAutographSort != 0)
            {
                if (SearchSortViewModel.IsOnCardAutographSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.IsOnCardAutograph);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.IsOnCardAutograph);
                }
            }
            if (SearchSortViewModel.IsPatchSort != 0)
            {
                if (SearchSortViewModel.IsPatchSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.IsPatch);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.IsPatch);
                }
            }
            if (SearchSortViewModel.IsGameWornJerseySort != 0)
            {
                if (SearchSortViewModel.IsGameWornJerseySort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.IsGameWornJersey);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.IsGameWornJersey);
                }
            }
            if (SearchSortViewModel.CopiesSort != 0)
            {
                if (SearchSortViewModel.CopiesSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Copies);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Copies);
                }
            }
            if (SearchSortViewModel.SerialNumberSort != 0)
            {
                if (SearchSortViewModel.SerialNumberSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.SerialNumber);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.SerialNumber);
                }
            }
            if (SearchSortViewModel.GradeSort != 0)
            {
                if (SearchSortViewModel.GradeSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Grade);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Grade);
                }
            }
            if (SearchSortViewModel.SportSort != 0)
            {
                if (SearchSortViewModel.SportSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Sport.Name);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Sport.Name);
                }
            }
            if (SearchSortViewModel.YearSort != 0)
            {
                if (SearchSortViewModel.YearSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Year.BeginningYear).ThenBy(x =>x.Year.EndingYear);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Sport.Name).ThenByDescending(x => x.Year.EndingYear);
                }
            }
            if (SearchSortViewModel.SetSort != 0)
            {
                if (SearchSortViewModel.SetSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Set.Name);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Set.Name);
                }
            }
            if (SearchSortViewModel.GradeCompanySort != 0)
            {
                if (SearchSortViewModel.GradeCompanySort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.GradeCompany.Name);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.GradeCompany.Name);
                }
            }
            if (SearchSortViewModel.LocationSort != 0)
            {
                if (SearchSortViewModel.LocationSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.Location.Name);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.Location.Name);
                }
            }
            if (SearchSortViewModel.TimeStampSort != 0)
            {
                if (SearchSortViewModel.TimeStampSort == 1)
                {
                    CardViewModels = CardViewModels.OrderBy(x => x.TimeStamp);
                }
                else
                {
                    CardViewModels = CardViewModels.OrderByDescending(x => x.TimeStamp);
                }
            }
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
            SearchSortViewModels = await _searchSortService.GetSearchSortAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
