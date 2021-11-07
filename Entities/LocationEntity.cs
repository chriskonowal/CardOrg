using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The location entity model
    /// </summary>
    public class LocationEntity
    {
        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
