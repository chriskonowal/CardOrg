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
    /// The year repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.IYearRepository" />
    public class YearRepository : IYearRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="YearRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public YearRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // <inheritdoc/>
        public async Task<int> InsertYearAsync(YearEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Years
                        (
                        BeginningYear,
                        EndingYear
                        )
                        VALUES
                        (
                        @BeginningYear, 
                        @EndingYear) ";

            var parameters = new DynamicParameters();
            parameters.Add("@BeginningYear", entity.BeginningYear);
            parameters.Add("@EndingYear", entity.EndingYear);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        // <inheritdoc/>
        public async Task<IEnumerable<YearEntity>> GetYearsAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Years ORDER BY BeginningYear DESC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<YearEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        // <inheritdoc/>
        public async Task<YearEntity> GetYearAsync(int yearId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.Years
                        WHERE YearId = @YearId";

            var parameters = new DynamicParameters();
            parameters.Add("@YearId", yearId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<YearEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        // <inheritdoc/>
        public async Task<int> UpdateYearAsync(YearEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Years
                        SET BeginningYear = @BeginningYear,
                        EndingYear = @EndingYear
                        WHERE YearId = @YearId";

            var parameters = new DynamicParameters();
            parameters.Add("@BeginningYear", entity.BeginningYear);
            parameters.Add("@EndingYear", entity.EndingYear);
            parameters.Add("@YearId", entity.YearId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        // <inheritdoc/>
        public async Task<int> DeleteYearAsync(int yearId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Years
                        WHERE YearId = @YearId";

            var parameters = new DynamicParameters();
            parameters.Add("@YearId", yearId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<YearEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.Years
                        WHERE YearId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<YearEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<YearEntity>();
        }
    }
}
