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
        /// Gets the cards asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<CardEntity>> GetCardsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Inserts the card asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertCardAsync(CardEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the card asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateCardAsync(CardEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the card asynchronously.
        /// </summary>
        /// <param name="cardId">The card identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteCardAsync(int cardId, CancellationToken cancellationToken);
    }
}
