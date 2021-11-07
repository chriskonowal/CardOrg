using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The set entity model
    /// </summary>
    public class SetEntity
    {
        /// <summary>
        /// Gets or sets the set identifier.
        /// </summary>
        /// <value>
        /// The set identifier.
        /// </value>
        public int SetId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
