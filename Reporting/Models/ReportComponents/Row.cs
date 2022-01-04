using System.Collections.Generic;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Row : ReportComponent
    {
        #region Fields

        private string _width = "100%";
        public List<ReportComponent> _children;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public Row()
        {
            _children = new List<ReportComponent>();
        }

        /// <summary>
        /// A row of ReportComponents.
        /// </summary>
        /// <param name="items">elements to put inside the row</param>
        public Row(params ReportComponent[] items)
        {
            _children = new List<ReportComponent>(items);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Add a ReportComponent to the end of the row.
        /// </summary>
        public void Add(ReportComponent component)
        {
            _children.Add(component);
        }

        public override Tag ToHtml()
        {
            Tag html = new Tag("table");

            // Set the table width & center it horizontally.
            html.AddAttribute("style", $"width: {_width}; margin: 0 auto;");

            // Create the html row container.
            Tag rowContainer = new Tag("tr");
            rowContainer.AddAttribute("style", $"width: 100%;");

            // Add data into the row.
            foreach (ReportComponent component in _children)
            {
                Tag rowData = new Tag("td");
                rowData.AddAttribute("style", "text-align: center;");
                rowData.AddContent(component.ToHtml());
                rowContainer.AddContent(rowData);
            }
            html.AddContent(rowContainer);
            return html;
        }


        #endregion Methods
    }
}
