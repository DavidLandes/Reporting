using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Text : ReportComponent
    {
        #region Fields


        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor for xml serialization.
        /// </summary>
        public Text()
        {

        }

        /// <summary>
        /// Creates a text box to be shown in a report.
        /// </summary>
        /// <param name="text"></param>
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
