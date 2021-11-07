using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The team card entity model
    /// </summary>
    public class TeamCardEntity
    {
        /// <summary>
        /// Gets or sets the team card identifier.
        /// </summary>
        /// <value>
        /// The team card identifier.
        /// </value>
        public int TeamCardId { get; set; }

        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>
        /// The team identifier.
        /// </value>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        public int CardId { get; set; }
    }
}
