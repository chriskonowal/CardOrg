using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The team view model
    /// </summary>
    public class TeamViewModel
    {
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>
        /// The team identifier.
        /// </value>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string City { get; set; }

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

        /// <summary>
        /// Gets the team.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public string Team => $"{City} {Name}";
    }
}
