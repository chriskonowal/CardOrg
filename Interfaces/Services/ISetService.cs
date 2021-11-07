using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The set service interface
    /// </summary>
    public interface ISetService
    {
        /// <summary>
        /// Gets the sets asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<SetViewModel>> GetSetsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the set asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveSetAsync(SetViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the set asynchronously.
        /// </summary>
        /// <param name="setId">The set identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<SetViewModel> GetSetAsync(int setId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the set asynchronously.
        /// </summary>
        /// <param name="setId">The set identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteSetAsync(int setId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<SetViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
