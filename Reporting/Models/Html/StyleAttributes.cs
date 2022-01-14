using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    /// <summary>
    /// Stores key-value pairs of HTML style attributes & their corresponding values. Ex: position: absolute; color: black;
    /// </summary>
    public class StyleAttributes : Dict
    {
        #region Methods

        /// <summary>
        /// Parse the key-values into an html attribute string. No styles means an empty string is returned.
        /// </summary>
        private string ParseStyles()
        {
            string res = "";
            string leadSpace = "";  // No space on the first property.
            foreach (string property in GetKeys())
            {
                string value = Get(property);
                res += $"{leadSpace}{property}: {value};";
                leadSpace = " ";
            }

            // If there are styles, add them to the style attribute.
            if (!string.IsNullOrWhiteSpace(res))
                res = $"style=\"{res}\"";

            return res;
        }

        public override string ToString()
        {
            return ParseStyles();
        }

        #endregion Methods
    }
}
