using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The sport entity model
    /// </summary>
    public class SportEntity
    {
        /// <summary>
        /// Gets or sets the sport identifier.
        /// </summary>
        /// <value>
        /// The sport identifier.
        /// </value>
        public int SportId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
