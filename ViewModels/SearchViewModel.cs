using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The search view model
    /// </summary>
    public class SearchViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is graded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is graded; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Is Graded")]
        public bool IsGraded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is rookie.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is rookie; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Is Rookie")]
        public bool IsRookie { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is autograph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is autograph; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Is Autograph")]
        public bool IsAutograph { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is patch.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is patch; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Is Patch")]
        public bool IsPatch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is on card autograph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is on card autograph; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Is On Card Autograph")]
        public bool IsOnCardAutograph { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is game worn jersey.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is game worn jersey; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Is Game Worn Jersey")]
        public bool IsGameWornJersey { get; set; }

        /// <summary>
        /// Gets or sets the player ids.
        /// </summary>
        /// <value>
        /// The player ids.
        /// </value>
        [DisplayName("Players")]
        public string PlayerIds { get; set; }

        /// <summary>
        /// Gets or sets the player ids.
        /// </summary>
        /// <value>
        /// The player ids.
        /// </value>
        [DisplayName("Teams")]
        public string TeamIds { get; set; }

        /// <summary>
        /// Gets or sets the sport ids.
        /// </summary>
        /// <value>
        /// The sport ids.
        /// </value>
        [DisplayName("Sports")]
        public string SportIds { get; set; }

        /// <summary>
        /// Gets or sets the year ids.
        /// </summary>
        /// <value>
        /// The year ids.
        /// </value>
        [DisplayName("Years")]
        public string YearIds { get; set; }

        /// <summary>
        /// Gets or sets the set ids.
        /// </summary>
        /// <value>
        /// The set ids.
        /// </value>
        [DisplayName("Sets")]
        public string SetIds { get; set; }

        /// <summary>
        /// Gets or sets the grade company identifier.
        /// </summary>
        /// <value>
        /// The grade company identifier.
        /// </value>
        [DisplayName("GradeCompanies")]
        public string GradeCompanyIds { get; set; }

        /// <summary>
        /// Gets or sets the location ids.
        /// </summary>
        /// <value>
        /// The location ids.
        /// </value>
        [DisplayName("Locations")]
        public string LocationIds { get; set; }

        /// <summary>
        /// Gets or sets the card description.
        /// </summary>
        /// <value>
        /// The card description.
        /// </value>
        [DisplayName("Card Description")]
        public string CardDescription { get; set; }
    }
}
