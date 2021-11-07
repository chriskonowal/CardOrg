using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The set view model converter
    /// </summary>
    public class SetViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SetViewModel Convert(SetEntity source)
        {
            return new SetViewModel()
            { 
                Name = source.Name,
                SetId = source.SetId
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static SetEntity Convert(SetViewModel source)
        {
            return new SetEntity()
            {
                Name = source.Name,
                SetId = source.SetId
            };
        }
    }
}
