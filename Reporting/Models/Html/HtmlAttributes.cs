using System.Collections.Generic;
using System.Linq;

namespace Reporting.Models.Html
{
    /// <summary>
    /// Stores key-value pairs of HTML tag attributes & their corresponding value. Ex: width="50px".
    /// </summary>
    public class HtmlAttributes : Dict
    {
        #region Methods

        /// <summary>
        /// Parse the key-values into an html attribute string. No attributes means an empty string is returned.
        /// </summary>
        private string ParseAttributes()
        {
            string res = "";
            string space = "";  // No space on the first attribute.
            foreach (string attr in GetKeys())
            {
                string value = Get(attr);
                res += $"{space}{attr}=\"{value}\"";
                space = " ";
            }
            return res;
        }

        public override string ToString()
        {
            return ParseAttributes();
        }

        #endregion Methods
    }
}
