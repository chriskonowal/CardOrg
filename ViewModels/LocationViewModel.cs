using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The locatoin view model
    /// </summary>
    public class LocationViewModel
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
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string Name { get; set; }
    }
}
