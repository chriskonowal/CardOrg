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
    /// The set repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.ISetRepository" />
    public class SetRepository : ISetRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public SetRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<int> InsertSetAsync(string name, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Sets 
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
        public async Task<IEnumerable<SetEntity>> GetSetsAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Sets ORDER BY Name ASC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<SetEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<SetEntity> GetSetAsync(int setId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.Sets
                        WHERE SetId = @SetId";

            var parameters = new DynamicParameters();
            parameters.Add("@SetId", setId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<SetEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdateSetAsync(SetEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Sets
                        SET Name = @Name
                        WHERE SetId = @SetId";

            var parameters = new DynamicParameters();
            parameters.Add("@SetId", entity.SetId);
            parameters.Add("@Name", entity.Name);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeleteSetAsync(int setId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Sets
                        WHERE SetId = @SetId";

            var parameters = new DynamicParameters();
            parameters.Add("@SetId", setId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SetEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.Sets
                        WHERE SetId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<SetEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<SetEntity>();
        }
    }
}
