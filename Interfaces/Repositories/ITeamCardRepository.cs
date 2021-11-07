using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The team card repository
    /// </summary>
    public interface ITeamCardRepository
    {
        Task<IEnumerable<TeamCardEntity>> GetTeamCardsAsync(IEnumerable<int> cardIds, CancellationToken cancellationToken);

        /// <summary>
        /// Inserts the team card asynchronously.
        /// </summary>
        /// <param name="cardId">The card identifier.</param>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertTeamCardAsync(int cardId, int teamId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the team card asynchronously.
        /// </summary>
        /// <param name="cardId">The card identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteTeamCardAsync(int cardId, CancellationToken cancellationToken);
    }
}
