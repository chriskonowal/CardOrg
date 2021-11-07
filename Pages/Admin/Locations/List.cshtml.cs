using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Locations
{
    /// <summary>
    /// The list model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ListModel : PageModel
    {
        private readonly ILocationService _locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="locationService">The location service.</param>
        public ListModel(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Gets or sets the location view models.
        /// </summary>
        /// <value>
        /// The location view models.
        /// </value>
        [BindProperty]
        public IEnumerable<LocationViewModel> LocationViewModels { get; set; }

        /// <summary>
        /// Gets or sets the location view model.
        /// </summary>
        /// <value>
        /// The location view model.
        /// </value>
        [BindProperty]
        public LocationViewModel LocationViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int locationId, CancellationToken cancellationToken)
        {
            LocationViewModels = await _locationService.GetLocationsAsync(cancellationToken);
            if (locationId > 0)
            {
                ViewData["Success"] = "Update your location.";
                var model = await _locationService.GetLocationAsync(locationId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                LocationViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a location.";
                LocationViewModel = new LocationViewModel();
            }

            return Page();
        }

        /// <summary>
        /// Called when [delete asynchronously].
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int locationId, CancellationToken cancellationToken)
        {
            await _locationService.DeleteLocationAsync(locationId, cancellationToken).ConfigureAwait(false);
            LocationViewModels = await _locationService.GetLocationsAsync(cancellationToken);
            LocationViewModel = new LocationViewModel();
            ViewData["Success"] = "Add another location.";
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

            var result = await _locationService.SaveLocationAsync(LocationViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            LocationViewModel = new LocationViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another location.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            LocationViewModels = await _locationService.GetLocationsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
