using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The year repository interface
    /// </summary>
    public interface IYearRepository
    {
        /// <summary>
        /// Inserts the year asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertYearAsync(YearEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the years asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<YearEntity>> GetYearsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the year asynchronously.
        /// </summary>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<YearEntity> GetYearAsync(int yearId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the year asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateYearAsync(YearEntity entity, CancellationToken cancellationToken);

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
        Task<IEnumerable<YearEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
