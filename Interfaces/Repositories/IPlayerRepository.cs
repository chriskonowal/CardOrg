using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The player repository interface
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Inserts the player asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertPlayerAsync(PlayerEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the players asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<PlayerEntity>> GetPlayersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the player asynchronously.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<PlayerEntity> GetPlayerAsync(int playerId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the player asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdatePlayerAsync(PlayerEntity entity, CancellationToken cancellationToken);

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
        Task<IEnumerable<PlayerEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
