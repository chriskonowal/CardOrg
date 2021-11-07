using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The sport repository interface
    /// </summary>
    public interface ISportRepository
    {
        /// <summary>
        /// Inserts the sport asynchronously.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertSportAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the sports asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<SportEntity>> GetSportsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the sport asynchronously.
        /// </summary>
        /// <param name="sportId">The sport identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<SportEntity> GetSportAsync(int sportId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the sport asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateSportAsync(SportEntity entity, CancellationToken cancellationToken);

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
        Task<IEnumerable<SportEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
