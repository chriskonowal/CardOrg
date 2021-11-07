using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The team service interface
    /// </summary>
    public interface ITeamService
    {
        /// <summary>
        /// Gets the teams asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TeamViewModel>> GetTeamsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the team asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveTeamAsync(TeamViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the team asynchronously.
        /// </summary>
        /// <param name="teamId">The team identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TeamViewModel> GetTeamAsync(int teamId, CancellationToken cancellationToken);

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
        Task<IEnumerable<TeamViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
