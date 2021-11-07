using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The player view model
    /// </summary>
    public class PlayerViewModel
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [DisplayName("First Name")]
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [DisplayName("Last Name")]
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName => $"{FirstName} {LastName}";
    }
}
