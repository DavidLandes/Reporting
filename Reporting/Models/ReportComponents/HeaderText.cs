using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    class HeaderText : HtmlTagBase
    {
        #region Fields


        #endregion Fields

        #region Constructors

        public HeaderText(string text, int headingSize=1)
        {
            _tag = $"h{headingSize}";
            _content.Add(text);
        }

        #endregion Constructors

        #region Methods


        #endregion Methods
    }
}
