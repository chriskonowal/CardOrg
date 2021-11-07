using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The year service interface
    /// </summary>
    public interface IYearService
    {
        /// <summary>
        /// Gets the years asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<YearViewModel>> GetYearsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the year asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveYearAsync(YearViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the year asynchronously.
        /// </summary>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<YearViewModel> GetYearAsync(int yearId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the year asynchronously.
        /// </summary>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteYearAsync(int yearId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<YearViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
