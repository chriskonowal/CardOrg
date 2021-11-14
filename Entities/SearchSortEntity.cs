using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    public class SearchSortEntity
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
        public bool IsGraded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is rookie.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is rookie; otherwise, <c>false</c>.
        /// </value>
        public bool IsRookie { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is autograph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is autograph; otherwise, <c>false</c>.
        /// </value>
        public bool IsAutograph { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is patch.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is patch; otherwise, <c>false</c>.
        /// </value>
        public bool IsPatch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is on card autograph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is on card autograph; otherwise, <c>false</c>.
        /// </value>
        public bool IsOnCardAutograph { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is game worn jersey.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is game worn jersey; otherwise, <c>false</c>.
        /// </value>
        public bool IsGameWornJersey { get; set; }

        /// <summary>
        /// Gets or sets the player ids.
        /// </summary>
        /// <value>
        /// The player ids.
        /// </value>
        public string PlayerIds { get; set; }

        /// <summary>
        /// Gets or sets the player ids.
        /// </summary>
        /// <value>
        /// The player ids.
        /// </value>
        public string TeamIds { get; set; }

        /// <summary>
        /// Gets or sets the sport ids.
        /// </summary>
        /// <value>
        /// The sport ids.
        /// </value>
        public string SportIds { get; set; }

        /// <summary>
        /// Gets or sets the year ids.
        /// </summary>
        /// <value>
        /// The year ids.
        /// </value>
        public string YearIds { get; set; }

        /// <summary>
        /// Gets or sets the set ids.
        /// </summary>
        /// <value>
        /// The set ids.
        /// </value>
        public string SetIds { get; set; }

        /// <summary>
        /// Gets or sets the grade company identifier.
        /// </summary>
        /// <value>
        /// The grade company identifier.
        /// </value>
        public string GradeCompanyIds { get; set; }

        /// <summary>
        /// Gets or sets the location ids.
        /// </summary>
        /// <value>
        /// The location ids.
        /// </value>
        public string LocationIds { get; set; }

        public string CardDescription { get; set; }

        public decimal LowestBecketPriceLow { get; set; }

        public decimal LowestBecketPriceHigh { get; set; }


        public decimal HighestBecketPriceLow { get; set; }

        public decimal HighestBecketPriceHigh { get; set; }

        public decimal LowestCOMCPriceLow { get; set; }

        public decimal LowestCOMCPriceHigh { get; set; }

        public decimal EbayPriceLow { get; set; }

        public decimal EbayPriceHigh { get; set; }

        public decimal PricePaidLow { get; set; }

        public decimal PricePaidHigh { get; set; }

        public decimal GradeLow { get; set; }

        public decimal GradeHigh { get; set; }

        public int CopiesLow { get; set; }

        public int CopiesHigh { get; set; }

        public int SerialNumberLow { get; set; }

        public int SerialNumberHigh { get; set; }

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
