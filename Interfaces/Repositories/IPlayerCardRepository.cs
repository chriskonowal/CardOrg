using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The player card repository interface
    /// </summary>
    public interface IPlayerCardRepository
    {
        /// <summary>
        /// Gets the player cards asynchronously.
        /// </summary>
        /// <param name="cardIds">The card ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<PlayerCardEntity>> GetPlayerCardsAsync(IEnumerable<int> cardIds, CancellationToken cancellationToken);

        /// <summary>
        /// Inserts the player card asynchronously.
        /// </summary>
        /// <param name="cardId">The card identifier.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertPlayerCardAsync(int cardId, int playerId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the player card asynchronously.
        /// </summary>
        /// <param name="cardId">The card identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeletePlayerCardAsync(int cardId, CancellationToken cancellationToken);
    }
}
