using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The player service interface
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Gets the players asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<PlayerViewModel>> GetPlayersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the player asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SavePlayerAsync(PlayerViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the player asynchronously.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<PlayerViewModel> GetPlayerAsync(int playerId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the player asynchronously.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeletePlayerAsync(int playerId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<PlayerViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
