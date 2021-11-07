using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Interfaces.Factories
{
    /// <summary>
    /// The sql connection factory interface
    /// </summary>
    public interface ISqlConnectionFactory
    {
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        SqlConnection CreateConnection();
    }
}
