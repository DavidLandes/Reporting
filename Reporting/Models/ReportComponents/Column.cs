using System.Collections.Generic;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Column : ReportComponent
    {
        #region Fields


        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public Column()
        {
            _children = new List<ReportComponent>();
        }

        /// <summary>
        /// A column of ReportComponents.
        /// </summary>
        /// <param name="items"></param>
        public Column(params ReportComponent[] items)
        {
            _children = new List<ReportComponent>(items);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Add a ReportComponent to the end of the column.
        /// </summary>
        public void Add(ReportComponent component)
        {
            _children.Add(component);
        }

        public override Tag ToHtml()
        {
            Tag html = new Tag("table");

            // Set the table size & center it horizontally.
            if (!string.IsNullOrWhiteSpace(Height))
                html.AddAttribute("height", Height);
            if (!string.IsNullOrWhiteSpace(Width))
                html.AddAttribute("width", Width);

            html.AddStyle("margin", $"0 auto");

            // Add data into the column by creating rows and stacking them on top of each other.
            foreach (ReportComponent component in _children)
            {
                // Create the html row container.
                Tag rowContainer = new Tag("tr");
                rowContainer.AddAttribute("width", $"100%");

                Tag rowData = new Tag("td");
                rowData.AddStyle("text-align", "center");
                rowData.AddContent(component.ToHtml());
                rowContainer.AddContent(rowData);

                // Add the row to the table.
                html.AddContent(rowContainer);
            }
            return html;
        }

        #endregion Methods
    }
}
