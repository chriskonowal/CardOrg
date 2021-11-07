using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public static class LocationViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static LocationViewModel Convert(LocationEntity source)
        {
            return new LocationViewModel()
            {
                LocationId = source.LocationId,
                Name = source.Name
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static LocationEntity Convert(LocationViewModel source)
        {
            return new LocationEntity()
            {
                LocationId = source.LocationId,
                Name = source.Name
            };
        }
    }
}
