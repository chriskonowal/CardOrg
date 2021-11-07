using CardOrg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Repositories
{
    /// <summary>
    /// The grade company repository interface
    /// </summary>
    public interface IGradeCompanyRepository
    {
        /// <summary>
        /// Inserts the grade company asynchronously.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> InsertGradeCompanyAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the grade companies asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<GradeCompanyEntity>> GetGradeCompaniesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the grade company asynchronously.
        /// </summary>
        /// <param name="gradeCompanyId">The grade company identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<GradeCompanyEntity> GetGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the grade company asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> UpdateGradeCompanyAsync(GradeCompanyEntity entity, CancellationToken cancellationToken);

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
        Task<IEnumerable<GradeCompanyEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    }
}
