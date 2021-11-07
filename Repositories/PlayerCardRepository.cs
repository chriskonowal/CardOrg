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
    /// The player card repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.IPlayerCardRepository" />
    public class PlayerCardRepository : IPlayerCardRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCardRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public PlayerCardRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PlayerCardEntity>> GetPlayerCardsAsync(IEnumerable<int> cardIds, CancellationToken cancellationToken)
        {
            if ((cardIds?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.PlayerCards
                        WHERE CardId IN ('{String.Join("','", cardIds)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<PlayerCardEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<PlayerCardEntity>();
        }
    }
}
