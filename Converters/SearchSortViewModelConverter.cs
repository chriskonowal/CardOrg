using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    public class SearchSortViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SearchSortEntity Convert(SearchSortViewModel source)
        {
            return new SearchSortEntity()
            { 
                CardDescription = source.CardDescription,
                CardDescriptionSort = source.CardDescriptionSort,
                CopiesHigh = source.CopiesHigh,
                CopiesLow = source.CopiesLow,
                CopiesSort = source.CopiesSort,
                EbayPriceHigh = source.EbayPriceHigh,
                EbayPriceLow = source.EbayPriceLow,
                EbayPriceSort = source.EbayPriceSort,
                GradeCompanyIds = source.GradeCompanyIds,
                GradeCompanySort = source.GradeCompanySort,
                GradeHigh = source.GradeHigh,
                GradeLow = source.GradeLow,
                GradeSort = source.GradeSort,
                HasImage = source.HasImage,
                HasImageSort = source.HasImageSort,
                HighestBecketPriceHigh = source.HighestBecketPriceHigh,
                HighestBecketPriceLow = source.HighestBecketPriceLow,
                HighestBeckettPriceSort = source.HighestBeckettPriceSort, 
                IsAutograph = source.IsAutograph,
                IsAutographSort = source.IsAutographSort,
                IsGameWornJersey = source.IsGameWornJersey,
                IsGameWornJerseySort = source.IsGameWornJerseySort,
                IsGraded = source.IsGraded,
                IsGradedSort = source.IsGradedSort,
                IsOnCardAutograph = source.IsOnCardAutograph,
                IsOnCardAutographSort = source.IsOnCardAutographSort,
                IsPatch = source.IsPatch,
                IsPatchSort = source.IsPatchSort,
                IsRookie = source.IsRookie,
                IsRookieSort = source.IsRookieSort,
                LocationIds = source.LocationIds,
                LocationSort = source.LocationSort,
                LowestBecketPriceHigh = source.LowestBecketPriceHigh,
                LowestBecketPriceLow = source.LowestBecketPriceLow,
                LowestBeckettPriceSort = source.LowestBeckettPriceSort,
                LowestCOMCPriceHigh = source.LowestCOMCPriceHigh,
                LowestCOMCPriceLow = source.LowestCOMCPriceLow,
                LowestCOMCPriceSort = source.LowestCOMCPriceSort,
                PlayerIds = source.PlayerIds,
                PlayerNameSort = source.PlayerNameSort,
                PricePaidHigh = source.PricePaidHigh,
                PricePaidLow = source.PricePaidLow,
                PricePaidSort = source.PricePaidSort,
                SerialNumberHigh = source.SerialNumberHigh, 
                SerialNumberLow = source.SerialNumberLow,
                SerialNumberSort = source.SerialNumberSort,
                SetIds = source.SetIds,
                SetSort = source.SetSort,
                SportIds = source.SportIds,
                SportSort = source.SportSort,
                TeamIds = source.TeamIds,
                TeamSort = source.TeamSort,
                TimeStampEnd = source.TimeStampEnd,
                TimeStampSort = source.TimeStampSort,
                TimeStampStart = source.TimeStampStart,
                YearIds = source.YearIds,
                YearSort = source.YearSort,
                TimeStamp = source.TimeStamp,
                Name = source.Name,
                Description = source.Description,
                SearchSortId = source.SearchSortId
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SearchSortViewModel Convert(SearchSortEntity source)
        {
            return new SearchSortViewModel()
            {
                CardDescription = source.CardDescription,
                CardDescriptionSort = source.CardDescriptionSort,
                CopiesHigh = source.CopiesHigh,
                CopiesLow = source.CopiesLow,
                CopiesSort = source.CopiesSort,
                EbayPriceHigh = source.EbayPriceHigh,
                EbayPriceLow = source.EbayPriceLow,
                EbayPriceSort = source.EbayPriceSort,
                GradeCompanyIds = source.GradeCompanyIds,
                GradeCompanySort = source.GradeCompanySort,
                GradeHigh = source.GradeHigh,
                GradeLow = source.GradeLow,
                GradeSort = source.GradeSort,
                HasImage = source.HasImage,
                HasImageSort = source.HasImageSort,
                HighestBecketPriceHigh = source.HighestBecketPriceHigh,
                HighestBecketPriceLow = source.HighestBecketPriceLow,
                HighestBeckettPriceSort = source.HighestBeckettPriceSort,
                IsAutograph = source.IsAutograph,
                IsAutographSort = source.IsAutographSort,
                IsGameWornJersey = source.IsGameWornJersey,
                IsGameWornJerseySort = source.IsGameWornJerseySort,
                IsGraded = source.IsGraded,
                IsGradedSort = source.IsGradedSort,
                IsOnCardAutograph = source.IsOnCardAutograph,
                IsOnCardAutographSort = source.IsOnCardAutographSort,
                IsPatch = source.IsPatch,
                IsPatchSort = source.IsPatchSort,
                IsRookie = source.IsRookie,
                IsRookieSort = source.IsRookieSort,
                LocationIds = source.LocationIds,
                LocationSort = source.LocationSort,
                LowestBecketPriceHigh = source.LowestBecketPriceHigh,
                LowestBecketPriceLow = source.LowestBecketPriceLow,
                LowestBeckettPriceSort = source.LowestBeckettPriceSort,
                LowestCOMCPriceHigh = source.LowestCOMCPriceHigh,
                LowestCOMCPriceLow = source.LowestCOMCPriceLow,
                LowestCOMCPriceSort = source.LowestCOMCPriceSort,
                PlayerIds = source.PlayerIds,
                PlayerNameSort = source.PlayerNameSort,
                PricePaidHigh = source.PricePaidHigh,
                PricePaidLow = source.PricePaidLow,
                PricePaidSort = source.PricePaidSort,
                SerialNumberHigh = source.SerialNumberHigh,
                SerialNumberLow = source.SerialNumberLow,
                SerialNumberSort = source.SerialNumberSort,
                SetIds = source.SetIds,
                SetSort = source.SetSort,
                SportIds = source.SportIds,
                SportSort = source.SportSort,
                TeamIds = source.TeamIds,
                TeamSort = source.TeamSort,
                TimeStampEnd = source.TimeStampEnd,
                TimeStampSort = source.TimeStampSort,
                TimeStampStart = source.TimeStampStart,
                YearIds = source.YearIds,
                YearSort = source.YearSort,
                TimeStamp = source.TimeStamp,
                Description = source.Description,
                Name = source.Name,
                SearchSortId = source.SearchSortId
            };
        }
    }
}
