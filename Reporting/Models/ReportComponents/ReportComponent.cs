using Reporting.Models.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.ReportComponents
{
    public class ReportComponent
    {
        #region Fields

        public HtmlTagBase Html;

        #endregion Fields

        public ReportComponent()
        {
            Html = new HtmlTagBase();
        }

        #region Methods

        public override string ToString()
        {
            return Html.ToString();
        }

        #endregion Methods
    }
}
