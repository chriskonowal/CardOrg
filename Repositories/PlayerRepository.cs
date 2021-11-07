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
    /// The player repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.IPlayerRepository" />
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public PlayerRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<int> InsertPlayerAsync(PlayerEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Players 
                        (FirstName, LastName)
                        VALUES(@FirstName, @LastName) ";

            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", entity.FirstName);
            parameters.Add("@LastName", entity.LastName);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PlayerEntity>> GetPlayersAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Players ORDER BY LastName ASC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<PlayerEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<PlayerEntity> GetPlayerAsync(int playerId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.Players
                        WHERE PlayerId = @PlayerId";

            var parameters = new DynamicParameters();
            parameters.Add("@PlayerId", playerId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<PlayerEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdatePlayerAsync(PlayerEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Players
                        SET FirstName = @FirstName,
                        LastName = @LastName
                        WHERE PlayerId = @PlayerId";

            var parameters = new DynamicParameters();
            parameters.Add("@PlayerId", entity.PlayerId);
            parameters.Add("@FirstName", entity.FirstName);
            parameters.Add("@LastName", entity.LastName);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeletePlayerAsync(int playerId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Players
                        WHERE PlayerId = @PlayerId";

            var parameters = new DynamicParameters();
            parameters.Add("@PlayerId", playerId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PlayerEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.Players
                        WHERE PlayerId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<PlayerEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<PlayerEntity>();
        }
    }
}
