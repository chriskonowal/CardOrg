using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The player card entity model
    /// </summary>
    public class PlayerCardEntity
    {
        /// <summary>
        /// Gets or sets the player card identifier.
        /// </summary>
        /// <value>
        /// The player card identifier.
        /// </value>
        public int PlayerCardId { get; set; }

        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        public int CardId { get; set; }
    }
}
