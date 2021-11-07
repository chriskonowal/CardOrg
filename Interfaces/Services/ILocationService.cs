using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The location service interface
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets the locations asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<LocationViewModel>> GetLocationsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the location asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveLocationAsync(LocationViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the location asynchronously.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<LocationViewModel> GetLocationAsync(int locationId, CancellationToken cancellationToken);

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
        Task<IEnumerable<LocationViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
