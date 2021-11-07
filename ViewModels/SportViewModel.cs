using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The sport view model
    /// </summary>
    public class SportViewModel
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
        [Required]
        [MinLength(1)]
        [MaxLength(254)]
        public string Name { get; set; }
    }
}
