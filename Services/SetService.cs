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
    /// The set service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.ISetService" />
    public class SetService : ISetService
    {
        private readonly ISetRepository _setRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetService"/> class.
        /// </summary>
        /// <param name="setRepository">The set repository.</param>
        public SetService(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SetViewModel>> GetSetsAsync(CancellationToken cancellationToken)
        {
            var entities = await _setRepository.GetSetsAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => SetViewModelConverter.Convert(x));
        }

        /// <inheritdoc/>
        public async Task<int> SaveSetAsync(SetViewModel model, CancellationToken cancellationToken)
        {
            if (model.SetId > 0)
            {
                var entity = SetViewModelConverter.Convert(model);
                return await _setRepository.UpdateSetAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _setRepository.InsertSetAsync(model.Name, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<SetViewModel> GetSetAsync(int setId, CancellationToken cancellationToken)
        {
            var entity = await _setRepository.GetSetAsync(setId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return SetViewModelConverter.Convert(entity);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteSetAsync(int setId, CancellationToken cancellationToken)
        {
            return await _setRepository.DeleteSetAsync(setId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SetViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _setRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => SetViewModelConverter.Convert(x));
        }
    }
}
