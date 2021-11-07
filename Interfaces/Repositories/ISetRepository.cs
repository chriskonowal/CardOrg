using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The set repository interface
    /// </summary>
    public interface ISetRepository
    {
        /// <summary>
        /// Inserts the set asynchronously.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertSetAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the sets asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<SetEntity>> GetSetsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the set asynchronously.
        /// </summary>
        /// <param name="setId">The set identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<SetEntity> GetSetAsync(int setId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the set asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateSetAsync(SetEntity entity, CancellationToken cancellationToken);

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
        Task<IEnumerable<SetEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
