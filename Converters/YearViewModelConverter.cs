using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The year view model converter
    /// </summary>
    public static class YearViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static YearViewModel Convert(YearEntity source)
        {
            return new YearViewModel()
            { 
                BeginningYear = source.BeginningYear,
                EndingYear = source.EndingYear,
                YearId = source.YearId
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static YearEntity Convert(YearViewModel source)
        {
            return new YearEntity()
            {
                BeginningYear = source.BeginningYear,
                EndingYear = source.EndingYear,
                YearId = source.YearId
            };
        }
    }
}
