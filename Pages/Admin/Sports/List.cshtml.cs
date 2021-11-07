using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Sports
{
    /// <summary>
    /// The list model
    /// </summary>
    public class ListModel : PageModel
    {
        private readonly ISportService _sportService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="sportService"></param>
        public ListModel(ISportService sportService)
        {
            _sportService = sportService;
        }

        /// <summary>
        /// Gets or sets the sport view model
        /// </summary>
        [BindProperty]
        public IEnumerable<SportViewModel> SportViewModels { get; set; }

        /// <summary>
        /// Gets or sets the sport view model.
        /// </summary>
        /// <value>
        /// The sport view model.
        /// </value>
        [BindProperty]
        public SportViewModel SportViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int sportId, CancellationToken cancellationToken)
        {
            SportViewModels = await _sportService.GetSportsAsync(cancellationToken);
            if (sportId > 0)
            {
                ViewData["Success"] = "Update your sport.";
                var model = await _sportService.GetSportAsync(sportId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                SportViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a sport.";
                SportViewModel = new SportViewModel();
            }
           
            return Page();
        }

        /// <summary>
        /// Called when [delete asynchronously].
        /// </summary>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int sportId, CancellationToken cancellationToken)
        {
            await _sportService.DeleteSportAsync(sportId, cancellationToken).ConfigureAwait(false);
            SportViewModels = await _sportService.GetSportsAsync(cancellationToken);
            SportViewModel = new SportViewModel();
            ViewData["Success"] = "Add another sport.";
            return Page();
        }

        /// <summary>
        /// Called when [post save asynchronously].
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostSaveAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _sportService.SaveSportAsync(SportViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            SportViewModel = new SportViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another sport.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            SportViewModels = await _sportService.GetSportsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
