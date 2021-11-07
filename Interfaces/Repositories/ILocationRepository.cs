using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The location repository interface
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Inserts the location asynchronously.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertLocationAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the locations asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<LocationEntity>> GetLocationsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the location asynchronously.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<LocationEntity> GetLocationAsync(int locationId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the location asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateLocationAsync(LocationEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the location asynchronously.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteLocationAsync(int locationId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<LocationEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
