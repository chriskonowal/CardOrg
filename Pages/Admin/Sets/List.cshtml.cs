using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Sets
{
    /// <summary>
    /// The list model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ListModel : PageModel
    {
        private readonly ISetService _setService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="locationService">The location service.</param>
        public ListModel(ISetService setService)
        {
            _setService = setService;
        }

        /// <summary>
        /// Gets or sets the set view models.
        /// </summary>
        /// <value>
        /// The set view models.
        /// </value>
        [BindProperty]
        public IEnumerable<SetViewModel> SetViewModels { get; set; }

        /// <summary>
        /// Gets or sets the set view model.
        /// </summary>
        /// <value>
        /// The set view model.
        /// </value>
        [BindProperty]
        public SetViewModel SetViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int setId, CancellationToken cancellationToken)
        {
            SetViewModels = await _setService.GetSetsAsync(cancellationToken);
            if (setId > 0)
            {
                ViewData["Success"] = "Update your set.";
                var model = await _setService.GetSetAsync(setId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                SetViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a set.";
                SetViewModel = new SetViewModel();
            }

            return Page();
        }

        /// <summary>
        /// Called when [delete asynchronously].
        /// </summary>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int setId, CancellationToken cancellationToken)
        {
            await _setService.DeleteSetAsync(setId, cancellationToken).ConfigureAwait(false);
            SetViewModels = await _setService.GetSetsAsync(cancellationToken);
            SetViewModel = new SetViewModel();
            ViewData["Success"] = "Add another set.";
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

            var result = await _setService.SaveSetAsync(SetViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            SetViewModel = new SetViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another set.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            SetViewModels = await _setService.GetSetsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
