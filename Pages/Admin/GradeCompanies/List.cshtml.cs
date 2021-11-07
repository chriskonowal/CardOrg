using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.GradeCompanies
{
    /// <summary>
    /// The list model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ListModel : PageModel
    {
        private readonly IGradeCompanyService _gradeCompanyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="gradeCompanyService">The grade company service.</param>
        public ListModel(IGradeCompanyService gradeCompanyService)
        {
            _gradeCompanyService = gradeCompanyService;
        }

        /// <summary>
        /// Gets or sets the grade company view models.
        /// </summary>
        /// <value>
        /// The grade company view models.
        /// </value>
        [BindProperty]
        public IEnumerable<GradeCompanyViewModel> GradeCompanyViewModels { get; set; }

        /// <summary>
        /// Gets or sets the grade company view model.
        /// </summary>
        /// <value>
        /// The grade company view model.
        /// </value>
        [BindProperty]
        public GradeCompanyViewModel GradeCompanyViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="gradeCompanyId">The grade company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int gradeCompanyId, CancellationToken cancellationToken)
        {
            GradeCompanyViewModels = await _gradeCompanyService.GetGradeCompaniesAsync(cancellationToken);
            if (gradeCompanyId > 0)
            {
                ViewData["Success"] = "Update your grade company.";
                var model = await _gradeCompanyService.GetGradeCompanyAsync(gradeCompanyId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                GradeCompanyViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a grade company.";
                GradeCompanyViewModel = new GradeCompanyViewModel();
            }

            return Page();
        }

        /// <summary>
        /// Called when [post delete asynchronously].
        /// </summary>
        /// <param name="gradeCompanyId">The grade company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int gradeCompanyId, CancellationToken cancellationToken)
        {
            await _gradeCompanyService.DeleteGradeCompanyAsync(gradeCompanyId, cancellationToken).ConfigureAwait(false);
            GradeCompanyViewModels = await _gradeCompanyService.GetGradeCompaniesAsync(cancellationToken);
            GradeCompanyViewModel = new GradeCompanyViewModel();
            ViewData["Success"] = "Add another grade company.";
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

            var result = await _gradeCompanyService.SaveGradeCompanyAsync(GradeCompanyViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            GradeCompanyViewModel = new GradeCompanyViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another grade company.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            GradeCompanyViewModels = await _gradeCompanyService.GetGradeCompaniesAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
