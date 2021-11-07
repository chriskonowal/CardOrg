using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The grade company entity model
    /// </summary>
    public class GradeCompanyEntity
    {
        /// <summary>
        /// Gets or sets the grade company identifier.
        /// </summary>
        /// <value>
        /// The grade company identifier.
        /// </value>
        public int GradeCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
