using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    class Text : ReportComponent
    {
        #region Fields


        #endregion Fields

        #region Constructors

        public Text(string text)
        {
            Html = new Tag("p");
            Html.AddContent(text);
        }

        #endregion Constructors

        #region Methods


        #endregion Methods
    }
}
