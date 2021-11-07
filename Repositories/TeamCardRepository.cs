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
    /// The team card repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.ITeamCardRepository" />
    public class TeamCardRepository : ITeamCardRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCardRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public TeamCardRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TeamCardEntity>> GetTeamCardsAsync(IEnumerable<int> cardIds, CancellationToken cancellationToken)
        {
            if ((cardIds?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.TeamCards
                        WHERE CardId IN ('{String.Join("','", cardIds)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<TeamCardEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<TeamCardEntity>();
        }

        /// <inheritdoc/>
        public async Task<int> InsertTeamCardAsync(int cardId, int teamId, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.TeamCards 
                        (CardId, TeamId)
                        VALUES(@CardId, @TeamId) ";

            var parameters = new DynamicParameters();
            parameters.Add("@CardId", cardId);
            parameters.Add("@TeamId", teamId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeleteTeamCardAsync(int cardId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.TeamCards
                        WHERE CardId = @CardId";

            var parameters = new DynamicParameters();
            parameters.Add("@CardId", cardId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }
    }
}
