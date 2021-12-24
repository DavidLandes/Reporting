using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class HeadingText : ReportComponent
    {
        #region Fields


        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor for xml serialization. 
        /// </summary>
        public HeadingText()
        {

        }

        public HeadingText(string text, int headingSize=1)
        {
            if (headingSize < 1 || headingSize > 6)
            {
                Console.WriteLine($"HeaderText size \'{headingSize}\' invalid. Must be a valid html heading size (1-6). Defaulting to <h1>");
                headingSize = 1;
            }

            Html = new Tag($"h{headingSize}");
            Html.AddContent(text);
        }

        #endregion Constructors

        #region Methods


        #endregion Methods
    }
}
