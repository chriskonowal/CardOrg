using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The card repository interface
    /// </summary>
    public interface ICardRepository
    {
        /// <summary>
        /// Inserts the record asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertRecordAsync(CardEntity entity, CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets the cards asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<CardEntity>> GetCardsAsync(CancellationToken cancellationToken);
    }
}
