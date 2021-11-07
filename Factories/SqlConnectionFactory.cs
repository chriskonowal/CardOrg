using CardOrg.Interfaces.Factories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Factory
{
    /// <summary>
    /// The sql connection factory
    /// </summary>
    /// <seealso cref="CardOrg.Interfaces.Factories.ISqlConnectionFactory" />
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public SqlConnection CreateConnection()
        { 
            var connectionString = _configuration.GetConnectionString("CardOrg");
            return new SqlConnection(connectionString);
        }
    }
}
