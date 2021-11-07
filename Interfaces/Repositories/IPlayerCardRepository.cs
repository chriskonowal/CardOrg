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
    }
}
