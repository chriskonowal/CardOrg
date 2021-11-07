using CardOrg.Entities;
using CardOrg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Converters
{
    /// <summary>
    /// The grade company view model converter
    /// </summary>
    public static class GradeCompanyViewModelConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static GradeCompanyViewModel Convert(GradeCompanyEntity source)
        {
            return new GradeCompanyViewModel()
            { 
                GradeCompanyId = source.GradeCompanyId,
                Name = source.Name
            };
        }

        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static GradeCompanyEntity Convert(GradeCompanyViewModel source)
        {
            return new GradeCompanyEntity()
            {
                GradeCompanyId = source.GradeCompanyId,
                Name = source.Name
            };
        }
    }
}
