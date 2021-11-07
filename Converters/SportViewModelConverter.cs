using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The sport view model converter
    /// </summary>
    public static class SportViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SportViewModel Convert(SportEntity source)
        {
            return new SportViewModel()
            {
                Name = source.Name,
                SportId = source.SportId
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SportEntity Convert(SportViewModel source)
        {
            return new SportEntity()
            { 
                Name = source.Name,
                SportId = source.SportId
            };
        }
    }
}
