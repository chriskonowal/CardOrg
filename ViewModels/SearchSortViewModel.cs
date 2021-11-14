using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    /// <summary>
    /// The search view model
    /// </summary>
    public class SearchSortViewModel
    {
        public int SearchSortId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
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
        
        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal LowestBecketPriceLow { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal LowestBecketPriceHigh { get; set; }


        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal HighestBecketPriceLow { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal HighestBecketPriceHigh { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal LowestCOMCPriceLow { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal LowestCOMCPriceHigh { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal EbayPriceLow { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal EbayPriceHigh { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal PricePaidLow { get; set; }

        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal PricePaidHigh { get; set; }

        [Required]
        [Range(0, 10)]
        [DefaultValue(0)]
        public decimal GradeLow { get; set; }

        [Required]
        [Range(0, 10)]
        [DefaultValue(0)]
        public decimal GradeHigh { get; set; }

        [Required]
        [Range(0, 100000)]
        [DefaultValue(0)]
        public int CopiesLow { get; set; }

        [Required]
        [Range(0, 100000)]
        [DefaultValue(0)]
        public int CopiesHigh { get; set; }

        [Required]
        [Range(0, 10000000000)]
        [DefaultValue(0)]
        public int SerialNumberLow { get; set; }

        [Required]
        [Range(0, 10000000000)]
        [DefaultValue(0)]
        public int SerialNumberHigh { get; set; }

        [DisplayName("Has Image")]
        public bool HasImage { get; set; }

        public DateTime? TimeStampStart { get; set; }

        public DateTime? TimeStampEnd { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <value>
        /// The last name of the player.
        /// </value>
        public int PlayerNameSort { get; set; }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public int TeamSort { get; set; }

        /// <summary>
        /// Gets or sets the card description.
        /// </summary>
        /// <value>
        /// The card description.
        /// </value>
        public int CardDescriptionSort { get; set; }

        public int LowestBeckettPriceSort { get; set; }

        public int HighestBeckettPriceSort { get; set; }

        public int LowestCOMCPriceSort { get; set; }

        public int EbayPriceSort { get; set; }

        public int PricePaidSort { get; set; }

        public int HasImageSort { get; set; }

        public int IsGradedSort { get; set; }

        public int CopiesSort { get; set; }

        public int SerialNumberSort { get; set; }

        public int GradeSort { get; set; }

        public int IsRookieSort { get; set; }

        public int IsAutographSort { get; set; }

        public int IsPatchSort { get; set; }

        public int IsOnCardAutographSort { get; set; }

        public int IsGameWornJerseySort { get; set; }

        public int SportSort { get; set; }

        public int YearSort { get; set; }

        public int SetSort { get; set; }

        public int GradeCompanySort { get; set; }

        public int LocationSort { get; set; }

        public int TimeStampSort { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
