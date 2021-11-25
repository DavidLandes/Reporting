using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.Html
{
    class Column : HtmlTagBase
    {
        #region Fields

        private string _width;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A column of html elements.
        /// </summary>
        /// <param name="items">Html elements to put inside the column</param>
        public Column(params HtmlTagBase[] items)
        {
            _tag = "table";
            _width = "100%";

            // Set the table width & center it horizontally.
            AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            // Add data into the column by creating rows and stacking them on top of each other.
            foreach (HtmlTagBase tag in items)
            {
                // Create the html row container.
                Tag rowContainer = new Tag("tr");
                rowContainer.AddAttribute("style", $"width: 100%;");

                Tag rowData = new Tag("td");
                rowData.AddAttribute("style", "text-align: center;");
                rowData.AddContent(tag);
                rowContainer.AddContent(rowData);

                // Add the row to the table.
                _content.Add(rowContainer);
            }
        }

        #endregion Constructors
    }
}
