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
    /// The grade company service
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Services.IGradeCompanyService" />
    public class GradeCompanyService : IGradeCompanyService
    {
        private readonly IGradeCompanyRepository _gradeCompanyRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportService"/> class.
        /// </summary>
        /// <param name="sportRepository">The sport repository.</param>
        public GradeCompanyService(IGradeCompanyRepository gradeCompanyRepository)
        {
            _gradeCompanyRepository = gradeCompanyRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GradeCompanyViewModel>> GetGradeCompaniesAsync(CancellationToken cancellationToken)
        {
            var entities = await _gradeCompanyRepository.GetGradeCompaniesAsync(cancellationToken).ConfigureAwait(false);
            return entities.Select(x => GradeCompanyViewModelConverter.Convert(x));
        }

        /// <inheritdoc/>
        public async Task<int> SaveGradeCompanyAsync(GradeCompanyViewModel model, CancellationToken cancellationToken)
        {
            if (model.GradeCompanyId > 0)
            {
                var entity = GradeCompanyViewModelConverter.Convert(model);
                return await _gradeCompanyRepository.UpdateGradeCompanyAsync(entity, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return await _gradeCompanyRepository.InsertGradeCompanyAsync(model.Name, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<GradeCompanyViewModel> GetGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken)
        {
            var entity = await _gradeCompanyRepository.GetGradeCompanyAsync(gradeCompanyId, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                return null;
            }
            return GradeCompanyViewModelConverter.Convert(entity);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken)
        {
            return await _gradeCompanyRepository.DeleteGradeCompanyAsync(gradeCompanyId, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GradeCompanyViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            var entities = await _gradeCompanyRepository.GetByIdsAsync(ids, cancellationToken).ConfigureAwait(false);
            return entities.Select(x => GradeCompanyViewModelConverter.Convert(x));
        }
    }
}
