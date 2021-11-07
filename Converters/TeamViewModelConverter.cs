using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The team view model converter
    /// </summary>
    public class TeamViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TeamViewModel Convert(TeamEntity source)
        {
            return new TeamViewModel()
            { 
                City = source.City,
                Name = source.Name,
                TeamId = source.TeamId
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TeamEntity Convert(TeamViewModel source)
        {
            return new TeamEntity()
            {
                City = source.City,
                Name = source.Name,
                TeamId = source.TeamId
            };
        }
    }
}
