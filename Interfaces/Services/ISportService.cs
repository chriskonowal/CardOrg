using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The sport service interface
    /// </summary>
    public interface ISportService
    {
        /// <summary>
        /// Gets the sports asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<SportViewModel>> GetSportsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the sport asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveSportAsync(SportViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the sport asynchronously.
        /// </summary>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<SportViewModel> GetSportAsync(int sportId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the sport asynchronously.
        /// </summary>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteSportAsync(int sportId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<SportViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
