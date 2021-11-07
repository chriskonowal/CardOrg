using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Teams
{
    /// <summary>
    /// The list model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ListModel : PageModel
    {
        private readonly ITeamService _teamService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="teamService">The team service.</param>
        public ListModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Gets or sets the team view models.
        /// </summary>
        /// <value>
        /// The team view models.
        /// </value>
        [BindProperty]
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }

        /// <summary>
        /// Gets or sets the team view model.
        /// </summary>
        /// <value>
        /// The team view model.
        /// </value>
        [BindProperty]
        public TeamViewModel TeamViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int teamId, CancellationToken cancellationToken)
        {
            TeamViewModels = await _teamService.GetTeamsAsync(cancellationToken);
            if (teamId > 0)
            {
                ViewData["Success"] = "Update your team.";
                var model = await _teamService.GetTeamAsync(teamId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                TeamViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a team.";
                TeamViewModel = new TeamViewModel();
            }

            return Page();
        }

        /// <summary>
        /// Called when [post delete asynchronously].
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int teamId, CancellationToken cancellationToken)
        {
            await _teamService.DeleteTeamAsync(teamId, cancellationToken).ConfigureAwait(false);
            TeamViewModels = await _teamService.GetTeamsAsync(cancellationToken);
            TeamViewModel = new TeamViewModel();
            ViewData["Success"] = "Add another player.";
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

            var result = await _teamService.SaveTeamAsync(TeamViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            TeamViewModel = new TeamViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another team.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            TeamViewModels = await _teamService.GetTeamsAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
