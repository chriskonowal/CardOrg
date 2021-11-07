using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The player view model converter
    /// </summary>
    public static class PlayerViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static PlayerViewModel Convert(PlayerEntity source)
        {
            return new PlayerViewModel()
            { 
                FirstName = source.FirstName,
                LastName = source.LastName,
                PlayerId = source.PlayerId
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static PlayerEntity Convert(PlayerViewModel source)
        {
            return new PlayerEntity()
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                PlayerId = source.PlayerId
            };
        }
    }
}
