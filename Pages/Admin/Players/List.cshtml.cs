using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardOrg.Pages.Admin.Players
{
    /// <summary>
    /// The list model
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class ListModel : PageModel
    {
        private readonly IPlayerService _playerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListModel"/> class.
        /// </summary>
        /// <param name="playerService">The player service.</param>
        public ListModel(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Gets or sets the player view model models.
        /// </summary>
        /// <value>
        /// The player view model models.
        /// </value>
        [BindProperty]
        public IEnumerable<PlayerViewModel> PlayerViewModels { get; set; }

        /// <summary>
        /// Gets or sets the player view model.
        /// </summary>
        /// <value>
        /// The player view model.
        /// </value>
        [BindProperty]
        public PlayerViewModel PlayerViewModel { get; set; }

        /// <summary>
        /// Called when [get asynchronously].
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int playerId, CancellationToken cancellationToken)
        {
            PlayerViewModels = await _playerService.GetPlayersAsync(cancellationToken);
            if (playerId > 0)
            {
                ViewData["Success"] = "Update your player.";
                var model = await _playerService.GetPlayerAsync(playerId, cancellationToken).ConfigureAwait(false);
                if (model == null)
                {
                    return BadRequest();
                }
                PlayerViewModel = model;
            }
            else
            {
                ViewData["Success"] = "Add a player.";
                PlayerViewModel = new PlayerViewModel();
            }

            return Page();
        }

        /// <summary>
        /// Called when [post delete asynchronously].
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDeleteAsync(int playerId, CancellationToken cancellationToken)
        {
            await _playerService.DeletePlayerAsync(playerId, cancellationToken).ConfigureAwait(false);
            PlayerViewModels = await _playerService.GetPlayersAsync(cancellationToken);
            PlayerViewModel = new PlayerViewModel();
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

            var result = await _playerService.SavePlayerAsync(PlayerViewModel, cancellationToken).ConfigureAwait(false);
            ModelState.Clear();
            PlayerViewModel = new PlayerViewModel();
            if (result == 1)
            {
                ViewData["Success"] = "Success! Add another player.";
            }
            else
            {
                ViewData["Success"] = "Error!";
            }

            PlayerViewModels = await _playerService.GetPlayersAsync(cancellationToken).ConfigureAwait(false);
            return Page();
        }
    }
}
