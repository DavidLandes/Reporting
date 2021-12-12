using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Row : ReportComponent
    {
        #region Fields

        private string _width;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A row of html elements.
        /// </summary>
        /// <param name="items">elements to put inside the row</param>
        public Row(params ReportComponent[] items)
        {
            Html = new Tag("table");
            _width = "100%";

            // Set the table width & center it horizontally.
            Html.AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            // Create the html row container.
            Tag rowContainer = new Tag("tr");
            rowContainer.AddAttribute("style", $"width: 100%;");

            // Add data into the row.
            foreach (ReportComponent component in items)
            {
                Tag rowData = new Tag("td");
                rowData.AddAttribute("style", "text-align: center;");
                rowData.AddContent(component.Html);
                rowContainer.AddContent(rowData);
            }
            Html.AddContent(rowContainer);
        }

        #endregion Constructors

        #region Methods



        #endregion Methods
    }
}
