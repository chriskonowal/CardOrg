using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The card view model converter
    /// </summary>
    public static class CardViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static CardEntity Convert(CardViewModel source)
        {
            return new CardEntity()
            { 
                CardDescription = source.CardDescription,
                CardId = source.CardId,
                CardNumber = source.CardNumber,
                Copies = source.Copies, 
                EbayPrice = source.EbayPrice,
                Grade = source.Grade,
                GradeCompanyId = source.GradeCompanyId,
                HighestBeckettPrice = source.HighestBeckettPrice, 
                IsAutograph = source.IsAutograph,
                IsGameWornJersey = source.IsGameWornJersey,
                IsGraded = source.IsGraded,
                IsOnCardAutograph = source.IsOnCardAutograph,
                IsPatch = source.IsPatch, 
                IsRookie = source.IsRookie, 
                LocationId = source.LocationId,
                LowestBeckettPrice = source.LowestBeckettPrice,
                LowestCOMCPrice = source.LowestCOMCPrice, 
                PricePaid = source.PricePaid,
                SerialNumber = source.SerialNumber,
                SetId = source.SetId,
                SportId = source.SportId,
                YearId = source.YearId,
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static CardViewModel Convert(CardEntity source)
        {
            return new CardViewModel()
            { 
                CardDescription = source.CardDescription,
                CardId = source.CardId,
                CardNumber = source.CardNumber,
                Copies = source.Copies, 
                EbayPrice = source.EbayPrice,
                Grade = source.Grade,
                HighestBeckettPrice = source.HighestBeckettPrice,
                IsAutograph = source.IsAutograph,
                IsGameWornJersey = source.IsGameWornJersey,
                IsGraded = source.IsGraded,
                IsOnCardAutograph = source.IsOnCardAutograph, 
                IsPatch = source.IsPatch,
                IsRookie = source.IsRookie,
                LowestBeckettPrice = source.LowestBeckettPrice,
                LowestCOMCPrice = source.LowestCOMCPrice,
                PricePaid = source.PricePaid,
                SerialNumber = source.SerialNumber,
                BackCardMainImagePath = source.BackCardMainImagePath,
                BackCardThumbnailImagePath = source.BackCardThumbnailImagePath,
                FrontCardMainImagePath = source.FrontCardMainImagePath,
                FrontCardThumbnailImagePath = source.FrontCardThumbnailImagePath,
                GradeCompanyId = source.GradeCompanyId,
                SetId = source.SetId,
                LocationId = source.LocationId,
                SportId = source.SportId,
                YearId = source.YearId,
                TimeStamp = source.TimeStamp
            };
        }
    }
}
