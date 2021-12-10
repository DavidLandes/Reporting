using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    class Column : ReportComponent
    {
        #region Fields

        private string _width;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A column of html elements.
        /// </summary>
        /// <param name="items">Html elements to put inside the column</param>
        public Column(params ReportComponent[] items)
        {
            Html = new Tag("table");
            _width = "100%";

            // Set the table width & center it horizontally.
            Html.AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            // Add data into the column by creating rows and stacking them on top of each other.
            foreach (ReportComponent component in items)
            {
                // Create the html row container.
                Tag rowContainer = new Tag("tr");
                rowContainer.AddAttribute("style", $"width: 100%;");

                Tag rowData = new Tag("td");
                rowData.AddAttribute("style", "text-align: center;");
                rowData.AddContent(component.Html);
                rowContainer.AddContent(rowData);

                // Add the row to the table.
                Html.AddContent(rowContainer);
            }
        }

        #endregion Constructors
    }
}
