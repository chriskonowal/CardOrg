using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.Contexts
{
    /// <summary>
    /// The file context model
    /// </summary>
    public class FileContext
    {
        /// <summary>
        /// Gets or sets the name of the front main file.
        /// </summary>
        /// <value>
        /// The name of the front main file.
        /// </value>
        public string FrontMainFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the front thumbnail file.
        /// </summary>
        /// <value>
        /// The name of the front thumbnail file.
        /// </value>
        public string FrontThumbnailFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the back main file.
        /// </summary>
        /// <value>
        /// The name of the back main file.
        /// </value>
        public string BackMainFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the back thumbnail file.
        /// </summary>
        /// <value>
        /// The name of the back thumbnail file.
        /// </value>
        public string BackThumbnailFileName { get; set; }
    }
}
