using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.Html
{
    class HeaderText : HtmlTagBase
    {
        #region Fields


        #endregion Fields

        #region Constructors

        public HeaderText(string text, int headingSize=1)
        {
            if (headingSize < 1 || headingSize > 6)
            {
                Console.WriteLine($"HeaderText size \'{headingSize}\' invalid. Must be a valid html heading size (1-6). Defaulting to <h1>");
                headingSize = 1;
            }

            _tag = $"h{headingSize}";
            _content.Add(text);
        }

        #endregion Constructors

        #region Methods


        #endregion Methods
    }
}
