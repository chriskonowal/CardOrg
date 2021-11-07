using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Entities
{
    /// <summary>
    /// The card details entity model
    /// </summary>
    public class CardEntity
    {
        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        public int CardId { get; set; }

        /// <summary>
        /// Gets or sets the card description.
        /// </summary>
        /// <value>
        /// The card description.
        /// </value>
        public string CardDescription { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the lowest beckett price.
        /// </summary>
        /// <value>
        /// The lowest beckett price.
        /// </value>
        public decimal LowestBeckettPrice { get; set; }

        /// <summary>
        /// Gets or sets the highest beckett price.
        /// </summary>
        /// <value>
        /// The highest beckett price.
        /// </value>
        public decimal HighestBeckettPrice { get; set; }

        /// <summary>
        /// Gets or sets the front card main image path.
        /// </summary>
        /// <value>
        /// The front card main image path.
        /// </value>
        public string FrontCardMainImagePath { get; set; }

        /// <summary>
        /// Gets or sets the front card thumbnail image path.
        /// </summary>
        /// <value>
        /// The front card thumbnail image path.
        /// </value>
        public string FrontCardThumbnailImagePath { get; set; }

        /// <summary>
        /// Gets or sets the back card main image path.
        /// </summary>
        /// <value>
        /// The back card main image path.
        /// </value>
        public string BackCardMainImagePath { get; set; }

        /// <summary>
        /// Gets or sets the back card thumbnail image path.
        /// </summary>
        /// <value>
        /// The back card thumbnail image path.
        /// </value>
        public string BackCardThumbnailImagePath { get; set; }

        /// <summary>
        /// Gets or sets the lowest comc price.
        /// </summary>
        /// <value>
        /// The lowest comc price.
        /// </value>
        public decimal LowestCOMCPrice { get; set; }

        /// <summary>
        /// Gets or sets the ebay price.
        /// </summary>
        /// <value>
        /// The ebay price.
        /// </value>
        public decimal EbayPrice { get; set; }

        /// <summary>
        /// Gets or sets the price paid.
        /// </summary>
        /// <value>
        /// The price paid.
        /// </value>
        public decimal PricePaid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is graded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is graded; otherwise, <c>false</c>.
        /// </value>
        public bool IsGraded { get; set; }

        /// <summary>
        /// Gets or sets the copies.
        /// </summary>
        /// <value>
        /// The copies.
        /// </value>
        public int Copies { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public int SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public decimal Grade { get; set; }

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
        /// Gets or sets the sport identifier.
        /// </summary>
        /// <value>
        /// The sport identifier.
        /// </value>
        public int SportId { get; set; }

        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        public int YearId { get; set; }

        /// <summary>
        /// Gets or sets the set identifier.
        /// </summary>
        /// <value>
        /// The set identifier.
        /// </value>
        public int SetId { get; set; }

        /// <summary>
        /// Gets or sets the grade company identifier.
        /// </summary>
        /// <value>
        /// The grade company identifier.
        /// </value>
        public int GradeCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public DateTime TimeStamp { get; set; }
    }
}
