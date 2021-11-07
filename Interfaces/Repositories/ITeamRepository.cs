using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The team repository interface
    /// </summary>
    public interface ITeamRepository
    {
        /// <summary>
        /// Inserts the team asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertTeamAsync(TeamEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the teams asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TeamEntity>> GetTeamsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the team asynchronously.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TeamEntity> GetTeamAsync(int teamId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the team asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateTeamAsync(TeamEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the team asynchronously.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteTeamAsync(int teamId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TeamEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
