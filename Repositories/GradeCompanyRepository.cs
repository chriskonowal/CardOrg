using CardOrg.Entities;
using CardOrg.Interfaces.Factories;
using CardOrg.Interfaces.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardOrg.Repositories
{
    /// <summary>
    /// The grade company repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.IGradeCompanyRepository" />
    public class GradeCompanyRepository : IGradeCompanyRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeCompanyRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public GradeCompanyRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<int> InsertGradeCompanyAsync(string name, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.GradeCompanies 
                        (Name)
                        VALUES(@Name) ";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", name);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GradeCompanyEntity>> GetGradeCompaniesAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.GradeCompanies ORDER BY Name ASC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<GradeCompanyEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<GradeCompanyEntity> GetGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.GradeCompanies
                        WHERE GradeCompanyId = @GradeCompanyId";

            var parameters = new DynamicParameters();
            parameters.Add("@GradeCompanyId", gradeCompanyId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GradeCompanyEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdateGradeCompanyAsync(GradeCompanyEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.GradeCompanies
                        SET Name = @Name
                        WHERE GradeCompanyId = @GradeCompanyId";

            var parameters = new DynamicParameters();
            parameters.Add("@GradeCompanyId", entity.GradeCompanyId);
            parameters.Add("@Name", entity.Name);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeleteGradeCompanyAsync(int gradeCompanyId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.GradeCompanies
                        WHERE GradeCompanyId = @GradeCompanyId";

            var parameters = new DynamicParameters();
            parameters.Add("@GradeCompanyId", gradeCompanyId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GradeCompanyEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.GradeCompanies
                        WHERE GradeCompanyId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<GradeCompanyEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<GradeCompanyEntity>();
        }
    }
}
