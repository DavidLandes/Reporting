using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    class StyleAttribute : Dict
    {
        #region Methods

        /// <summary>
        /// Parse the key-values into an html attribute string.
        /// </summary>
        private string ParseStyles()
        {
            string res = "";
            string leadSpace = "";  // No space on the first attribute.
            foreach (string attr in GetKeys())
            {
                string value = Get(attr);
                res += $"{leadSpace}{attr}:\"{value}\";";
                leadSpace = " ";
            }
            return res;
        }

        public override string ToString()
        {
            return ParseStyles();
        }

        #endregion Methods
    }
}
