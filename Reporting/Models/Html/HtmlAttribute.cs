using System.Collections.Generic;
using System.Linq;

namespace Reporting.Models.Html
{
    public class HtmlAttribute : Dict
    {
        #region Methods

        /// <summary>
        /// Parse the key-values into an html attribute string.
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
