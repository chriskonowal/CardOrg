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
    /// The location repository
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Repositories.ILocationRepository" />
    public class LocationRepository : ILocationRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        public LocationRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <inheritdoc/>
        public async Task<int> InsertLocationAsync(string name, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO dbo.Locations 
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
        public async Task<IEnumerable<LocationEntity>> GetLocationsAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM dbo.Locations ORDER BY Name ASC";

            var parameters = new DynamicParameters();

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<LocationEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<LocationEntity> GetLocationAsync(int locationId, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * 
                        FROM dbo.Locations
                        WHERE LocationId = @LocationId";

            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", locationId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<LocationEntity>(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> UpdateLocationAsync(LocationEntity entity, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE dbo.Locations
                        SET Name = @Name
                        WHERE LocationId = @LocationId";

            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", entity.LocationId);
            parameters.Add("@Name", entity.Name);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<int> DeleteLocationAsync(int locationId, CancellationToken cancellationToken)
        {
            var sql = @"DELETE dbo.Locations
                        WHERE LocationId = @LocationId";

            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", locationId);

            var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.ExecuteAsync(commandDefinition).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LocationEntity>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            if ((ids?.Any()).GetValueOrDefault())
            {
                var sql = $@"SELECT * FROM dbo.Locations
                        WHERE LocationId IN ('{String.Join("','", ids)}')";

                var parameters = new DynamicParameters();

                var commandDefinition = new CommandDefinition(sql, parameters, commandType: System.Data.CommandType.Text, cancellationToken: cancellationToken);
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return await connection.QueryAsync<LocationEntity>(commandDefinition).ConfigureAwait(false);
                }
            }

            return Enumerable.Empty<LocationEntity>();
        }
    }
}
