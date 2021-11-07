using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Years
{
    /// <summary>
    /// The list model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ListModel : PageModel
    {
        private readonly IYearService _yearService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="sportService"></param>
        public ListModel(IYearService yearService)
        {
            _yearService = yearService;
        }

        /// <summary>
        /// Gets or sets the year view models.
        /// </summary>
        /// <value>
        /// The year view models.
        /// </value>
        [BindProperty]
        public IEnumerable<YearViewModel> YearViewModels { get; set; }

        [BindProperty]
        public YearViewModel YearViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int yearId, CancellationToken cancellationToken)
        {
            YearViewModels = await _yearService.GetYearsAsync(cancellationToken);
            if (yearId > 0)
            {
                ViewData["Success"] = "Update your year.";
                var model = await _yearService.GetYearAsync(yearId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                YearViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a year.";
                YearViewModel = new YearViewModel();
            }

            return Page();
        }

        /// <summary>
        /// Called when [post asynchronously].
        /// </summary>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int yearId, CancellationToken cancellationToken)
        {
            await _yearService.DeleteYearAsync(yearId, cancellationToken).ConfigureAwait(false);
            YearViewModels = await _yearService.GetYearsAsync(cancellationToken);
            YearViewModel = new YearViewModel();
            ViewData["Success"] = "Add another year.";
            return Page();
        }

        public async Task<IActionResult> OnPostSaveAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _yearService.SaveYearAsync(YearViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            YearViewModel = new YearViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another year.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            YearViewModels = await _yearService.GetYearsAsync(cancellationToken);
            return Page();
        }
    }
}
