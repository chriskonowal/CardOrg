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
    /// The sport repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.ISportRepository" />
    public class SportRepository : ISportRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public SportRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<int> InsertSportAsync(string name, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Sports 
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
        public async Task<IEnumerable<SportEntity>> GetSportsAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Sports ORDER BY Name ASC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<SportEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<SportEntity> GetSportAsync(int sportId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.Sports
                        WHERE SportId = @SportId";

            var parameters = new DynamicParameters();
            parameters.Add("@SportId", sportId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<SportEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdateSportAsync(SportEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Sports
                        SET Name = @Name
                        WHERE SportId = @SportId";

            var parameters = new DynamicParameters();
            parameters.Add("@SportId", entity.SportId);
            parameters.Add("@Name", entity.Name);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }
        
        /// <inheritdoc/>
        public async Task<int> DeleteSportAsync(int sportId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Sports
                        WHERE SportId = @SportId";

            var parameters = new DynamicParameters();
            parameters.Add("@SportId", sportId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SportEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.Sports
                        WHERE SportId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<SportEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<SportEntity>();
        }
    }
}
