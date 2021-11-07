using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The grade company view model
    /// </summary>
    public class GradeCompanyViewModel
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
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string Name { get; set; }
    }
}
