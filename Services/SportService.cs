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
    /// The sport service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.ISportService" />
    public class SportService : ISportService 
    {
        private readonly ISportRepository _sportRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportService"/> class.
        /// </summary>
        /// <param name="sportRepository">The sport repository.</param>
        public SportService(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SportViewModel>> GetSportsAsync(CancellationToken cancellationToken)
        {
            var entities = await _sportRepository.GetSportsAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => SportViewModelConverter.Convert(x));
        }

        /// <inheritdoc/>
        public async Task<int> SaveSportAsync(SportViewModel model, CancellationToken cancellationToken)
        {
            if (model.SportId > 0)
            {
                var entity = SportViewModelConverter.Convert(model);
                return await _sportRepository.UpdateSportAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _sportRepository.InsertSportAsync(model.Name, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<SportViewModel> GetSportAsync(int sportId, CancellationToken cancellationToken)
        {
            var entity = await _sportRepository.GetSportAsync(sportId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return SportViewModelConverter.Convert(entity);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteSportAsync(int sportId, CancellationToken cancellationToken)
        {
            return await _sportRepository.DeleteSportAsync(sportId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SportViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _sportRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => SportViewModelConverter.Convert(x));
        }
    }
}
