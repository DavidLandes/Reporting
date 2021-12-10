using Reporting.Models.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.ReportComponents
{
    class ReportComponent
    {
        #region Fields

        public HtmlTagBase Html;

        #endregion Fields



        #region Methods

        public override string ToString()
        {
            return Html.ToString();
        }

        #endregion Methods
    }
}
