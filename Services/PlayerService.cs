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
    /// The player service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.IPlayerService" />
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerService"/> class.
        /// </summary>
        /// <param name="playerRepository">The player repository.</param>
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PlayerViewModel>> GetPlayersAsync(CancellationToken cancellationToken)
        {
            var entities = await _playerRepository.GetPlayersAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => PlayerViewModelConverter.Convert(x));
        }

        /// <inheritdoc/>
        public async Task<int> SavePlayerAsync(PlayerViewModel model, CancellationToken cancellationToken)
        {
            var entity = PlayerViewModelConverter.Convert(model);
            if (entity.PlayerId > 0)
            {
                return await _playerRepository.UpdatePlayerAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _playerRepository.InsertPlayerAsync(entity, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<PlayerViewModel> GetPlayerAsync(int playerId, CancellationToken cancellationToken)
        {
            var entity = await _playerRepository.GetPlayerAsync(playerId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return PlayerViewModelConverter.Convert(entity);
        }

        /// <inheritdoc/>
        public async Task<int> DeletePlayerAsync(int playerId, CancellationToken cancellationToken)
        {
            return await _playerRepository.DeletePlayerAsync(playerId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PlayerViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _playerRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => PlayerViewModelConverter.Convert(x));
        }
    }
}
