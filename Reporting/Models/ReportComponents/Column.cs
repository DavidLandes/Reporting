using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Column : ReportComponent
    {
        #region Fields

        private string _width;
        public List<ReportComponent> Children;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor for xml serialization. 
        /// </summary>
        public Column()
        {
            //_width = "100%";
            //Html = new Tag("table");

            //// Set the table width & center it horizontally.
            //Html.AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            //Children = new List<ReportComponent>();
        }

        /// <summary>
        /// A column of html elements.
        /// </summary>
        /// <param name="items">Html elements to put inside the column</param>
        public Column(params ReportComponent[] items)
        {
            _width = "100%";
            Html = new Tag("table");

            // Set the table width & center it horizontally.
            Html.AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            // Add data into the column by creating rows and stacking them on top of each other.
            Children = new List<ReportComponent>(items);
            SetHTML();
        }

        public void SetHTML()
        {
            Html.ClearContent();

            // Add data into the column by creating rows and stacking them on top of each other.
            foreach (ReportComponent component in Children)
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
