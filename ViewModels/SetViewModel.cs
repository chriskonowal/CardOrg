using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The set view model
    /// </summary>
    public class SetViewModel
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
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string Name { get; set; }
    }
}
