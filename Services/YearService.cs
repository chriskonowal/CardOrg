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
    /// The year service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.IYearService" />
    public class YearService : IYearService
    {
        private readonly IYearRepository _yearRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearService"/> class.
        /// </summary>
        /// <param name="yearRepository">The year repository.</param>
        public YearService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        // <inheritdoc/>
        public async Task<IEnumerable<YearViewModel>> GetYearsAsync(CancellationToken cancellationToken)
        {
            var entities = await _yearRepository.GetYearsAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => YearViewModelConverter.Convert(x));
        }

        // <inheritdoc/>
        public async Task<int> SaveYearAsync(YearViewModel model, CancellationToken cancellationToken)
        {
            if (model.YearId > 0)
            {
                var entity = YearViewModelConverter.Convert(model);
                return await _yearRepository.UpdateYearAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var entity = YearViewModelConverter.Convert(model);
                return await _yearRepository.InsertYearAsync(entity, cancellationToken).ConfigureAwait(false);
            }
        }

        // <inheritdoc/>
        public async Task<YearViewModel> GetYearAsync(int yearId, CancellationToken cancellationToken)
        {
            var entity = await _yearRepository.GetYearAsync(yearId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return YearViewModelConverter.Convert(entity);
        }

        // <inheritdoc/>
        public async Task<int> DeleteYearAsync(int yearId, CancellationToken cancellationToken)
        {
            return await _yearRepository.DeleteYearAsync(yearId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<YearViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _yearRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => YearViewModelConverter.Convert(x));
        }
    }
}
