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
    /// The team repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.ITeamRepository" />
    public class TeamRepository : ITeamRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public TeamRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<int> InsertTeamAsync(TeamEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Teams 
                        (City, Name)
                        VALUES(@City, @Name) ";

            var parameters = new DynamicParameters();
            parameters.Add("@City", entity.City);
            parameters.Add("@Name", entity.Name);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TeamEntity>> GetTeamsAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Teams ORDER BY City ASC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<TeamEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<TeamEntity> GetTeamAsync(int teamId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.Teams
                        WHERE TeamId = @TeamId";

            var parameters = new DynamicParameters();
            parameters.Add("@TeamId", teamId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TeamEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdateTeamAsync(TeamEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Teams
                        SET City = @City,
                        Name = @Name
                        WHERE TeamId = @TeamId";

            var parameters = new DynamicParameters();
            parameters.Add("@City", entity.City);
            parameters.Add("@Name", entity.Name);
            parameters.Add("@TeamId", entity.TeamId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeleteTeamAsync(int teamId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Teams
                        WHERE TeamId = @TeamId";

            var parameters = new DynamicParameters();
            parameters.Add("@TeamId", teamId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TeamEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.Teams
                        WHERE TeamId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<TeamEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<TeamEntity>();
        }
    }
}
