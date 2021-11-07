using CardOrg.Converters;
using CardOrg.Interfaces.Repositories;
using CardOrg.Interfaces.Services;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Services
{
    /// <summary>
    /// The team service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.ITeamService" />
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamService"/> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TeamViewModel>> GetTeamsAsync(CancellationToken cancellationToken)
        {
            var entities = await _teamRepository.GetTeamsAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => TeamViewModelConverter.Convert(x));
        }

        /// <inheritdoc/>
        public async Task<int> SaveTeamAsync(TeamViewModel model, CancellationToken cancellationToken)
        {
            var entity = TeamViewModelConverter.Convert(model);
            if (entity.TeamId > 0)
            {
                return await _teamRepository.UpdateTeamAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _teamRepository.InsertTeamAsync(entity, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<TeamViewModel> GetTeamAsync(int teamId, CancellationToken cancellationToken)
        {
            var entity = await _teamRepository.GetTeamAsync(teamId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return TeamViewModelConverter.Convert(entity);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteTeamAsync(int teamId, CancellationToken cancellationToken)
        {
            return await _teamRepository.DeleteTeamAsync(teamId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TeamViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _teamRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => TeamViewModelConverter.Convert(x));
        }
    }
}
