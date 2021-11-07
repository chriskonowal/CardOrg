using CardOrg.Contexts;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The card service interface
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        /// Gets the cards asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<CardViewModel>> GetCardsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the card asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<bool> SaveCardAsync(CardViewModel model, CancellationToken cancellationToken);
    }
}
