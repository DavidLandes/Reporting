using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    class Row : HtmlTagBase
    {
        #region Fields

        private string _width;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A row of html elements.
        /// </summary>
        /// <param name="items">Html elements to put inside the row</param>
        public Row(params HtmlTagBase[] items)
        {
            _tag = "table";
            _width = "100%";

            // Set the table width & center it horizontally.
            AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            // Create the html row container.
            Tag rowContainer = new Tag("tr");
            rowContainer.AddAttribute("style", $"width: 100%;");

            // Add data into the row.
            foreach (HtmlTagBase tag in items)
            {
                Tag rowData = new Tag("td");
                rowData.AddAttribute("style", "text-align: center;");
                rowData.AddContent(tag);
                rowContainer.AddContent(rowData);
            }
            _content.Add(rowContainer);
        }

        #endregion Constructors

        #region Methods



        #endregion Methods
    }
}
