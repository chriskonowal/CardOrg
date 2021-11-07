using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardOrg.Extensions
{
    /// <summary>
    /// The string extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Strips the invalid file name characters.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string StripInvalidFileNameCharacters(this string source)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return String.Empty;
            }

            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                source = source.Replace(c.ToString(), "");
            }

            return source;
        }

        /// <summary>
        /// Returns the alpha numeric characters.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string ReturnAlphaNumericCharacters(this string source)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return String.Empty;
            }

            source = Regex.Replace(source, "[^a-zA-Z0-9]", String.Empty);
            return source;
        }
    }
}
