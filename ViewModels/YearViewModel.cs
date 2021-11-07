using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The year view model
    /// </summary>
    public class YearViewModel
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
        [DisplayName("Beginning Year")]
        [Required]
        [Range(1900, 3000)]
        public int BeginningYear { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        [DisplayName("Ending Year")]
        [Required]
        [Range(1900, 3000)]
        public int EndingYear { get; set; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public string Year
        {
            get
            {
                if (BeginningYear != EndingYear)
                {
                    return $"{BeginningYear}-{EndingYear}";
                }
                else
                {
                    return BeginningYear.ToString();
                }
            }
        }
    }
}
