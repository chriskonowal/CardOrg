using CardOrg.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ViewModels
{
    public class CardViewModel
    {
        /// <summary>
        /// Gets or sets the card identifier.
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        public int CardId { get; set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public IEnumerable<PlayerViewModel> Players { get; set; }

        /// <summary>
        /// Gets or sets the player ids.
        /// </summary>
        /// <value>
        /// The player ids.
        /// </value>
        [DisplayName("Players")]
        [Required]
        public string PlayerIds { get; set; }

        [Required]
        public IEnumerable<TeamViewModel> Teams { get; set; }

        /// <summary>
        /// Gets or sets the team ids.
        /// </summary>
        /// <value>
        /// The team ids.
        /// </value>
        [DisplayName("Teams")]
        [Required]
        public string TeamIds { get; set; }


        public GradeCompanyViewModel GradeCompany { get; set; }

        [DisplayName("Grade Company")]
        public int GradeCompanyId { get; set; }

        public LocationViewModel Location { get; set; }

        [DisplayName("Location")]
        [Required]
        public int LocationId { get; set; }

        public SetViewModel Set { get; set; }

        [DisplayName("Set")]
        [Required]
        public int SetId { get; set; }

        public SportViewModel Sport { get; set; }

        [DisplayName("Sport")]
        [Required]
        public int SportId { get; set; }

        public YearViewModel Year { get; set; }

        [DisplayName("Year")]
        [Required]
        public int YearId { get; set; }

        /// <summary>
        /// Gets or sets the card description.
        /// </summary>
        /// <value>
        /// The card description.
        /// </value>
        [DisplayName("Card Description")]
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string CardDescription { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        [DisplayName("Card Number")]
        [MinLength(1)]
        [MaxLength(254)]
        [Required]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the lowest Beckett price.
        /// </summary>
        /// <value>
        /// The lowest Beckett price.
        /// </value>
        [DisplayName("Lowest Beckett Price")]
        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal LowestBeckettPrice { get; set; }

        /// <summary>
        /// Gets or sets the highest Beckett price.
        /// </summary>
        /// <value>
        /// The highest Beckett price.
        /// </value>
        [DisplayName("Highest Beckett Price")]
        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal HighestBeckettPrice { get; set; }

        /// <summary>
        /// Gets or sets the upload.
        /// </summary>
        /// <value>
        /// The upload.
        /// </value>
        [DisplayName("Front Upload")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile FrontUpload { get; set; }

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
        /// Gets or sets the upload.
        /// </summary>
        /// <value>
        /// The upload.
        /// </value>
        [DisplayName("Back Upload")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile BackUpload { get; set; }

        /// <summary>
        /// Gets or sets the Lowest COMC Price
        /// </summary>
        [DisplayName("Lowest COMC Price")]
        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal LowestCOMCPrice { get; set; }

        /// <summary>
        /// Gets or sets the Ebay Price
        /// </summary>
        [DisplayName("Ebay Price")]
        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal EbayPrice { get; set; }

        /// <summary>
        /// Gets or sets the price paid
        /// </summary>
        [DisplayName("Price Paid")]
        [Required]
        [Range(0, 10000)]
        [DefaultValue(0)]
        public decimal PricePaid { get; set; }

        /// <summary>
        /// Gets or sets the Is Graded
        /// </summary>
        [DisplayName("Is Graded")]
        [Required]
        public bool IsGraded { get; set; }

        /// <summary>
        /// Gets or sets the copies of the card
        /// </summary>
        [DisplayName("Copies")]
        [Required]
        [DefaultValue(0)]
        public int Copies { get; set; }

        /// <summary>
        /// Gets or sets the serial number
        /// </summary>
        [DisplayName("Serial Number")]
        [Required]
        [DefaultValue(0)]
        public int SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the grade
        /// </summary>
        [DisplayName("Grade")]
        [Required]
        [Range(0, 10)]
        [DefaultValue(0)]
        public decimal Grade { get; set; }

        /// <summary>
        /// Gets or sets is rookie
        /// </summary>
        [DisplayName("IsRookie")]
        [Required]
        public bool IsRookie { get; set; }

        /// <summary>
        /// Gets or sets is autograph
        /// </summary>
        [DisplayName("IsAutograph")]
        [Required]
        public bool IsAutograph { get; set; }

        /// <summary>
        /// Gets or sets is patch.
        /// </summary>
        [DisplayName("IsPatch")]
        [Required]
        public bool IsPatch { get; set; }

        /// <summary>
        /// Gets or sets is on card autograph
        /// </summary>
        [DisplayName("IsOnCardAutograph")]
        [Required]
        public bool IsOnCardAutograph { get; set; }

        /// <summary>
        /// Gets or sets is game worn jersey
        /// </summary>
        [DisplayName("IsGameWornJersey")]
        [Required]
        public bool IsGameWornJersey { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public DateTime TimeStamp { get; set; }
    }
}
