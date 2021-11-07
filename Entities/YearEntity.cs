using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The year entity
    /// </summary>
    public class YearEntity
    {
        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        public int YearId { get; set; }

        /// <summary>
        /// Gets or sets the beginning year.
        /// </summary>
        /// <value>
        /// The beginning year.
        /// </value>
        public int BeginningYear { get; set; }

        /// <summary>
        /// Gets or sets the ending year.
        /// </summary>
        /// <value>
        /// The ending year.
        /// </value>
        public int EndingYear { get; set; }
    }
}
