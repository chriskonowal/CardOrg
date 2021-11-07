using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Services
{
    /// <summary>
    /// The grade company service interface
    /// </summary>
    public interface IGradeCompanyService
    {
        /// <summary>
        /// Gets the grade companies asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<GradeCompanyViewModel>> GetGradeCompaniesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Saves the grade company asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveGradeCompanyAsync(GradeCompanyViewModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the grade company asynchronously.
        /// </summary>
        /// <param name="gradeCompanyId">The grade company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<GradeCompanyViewModel> GetGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the grade company asynchronously.
        /// </summary>
        /// <param name="gradeCompanyId">The grade company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> DeleteGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets by ids asynchronously.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<GradeCompanyViewModel>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
