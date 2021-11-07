using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The team entity model
    /// </summary>
    public class TeamEntity
    {
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>
        /// The team identifier.
        /// </value>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
