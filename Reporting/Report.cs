using System.Collections.Generic;
using System.Xml.Serialization;
using Reporting.Models.Html;
using Reporting.Models.ReportComponents;

namespace Reporting
{
    [XmlInclude(typeof(Column))]
    [XmlInclude(typeof(HeadingText))]
    [XmlInclude(typeof(Row))]
    [XmlInclude(typeof(Table))]
    [XmlInclude(typeof(Text))]
    public class Report
    {

        #region Fields

        public List<ReportComponent> _content;

        #endregion Fields

        #region Constructors

        public Report()
        {
            _content = new List<ReportComponent>();
        }

        /// <summary>
        /// Create a report with the provided content. Items will be placed from top to bottom in the report, starting with the first content item.
        /// </summary>
        /// <param name="content"></param>
        public Report(params ReportComponent[] content)
        {
            _content = new List<ReportComponent>(content);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Append a ReportComponent to the end of this report.
        /// </summary>
        /// <param name="component"></param>
        public void Add(ReportComponent component)
        {
            _content.Add(component);
        }

        /// <summary>
        /// Return a string containing the report and all its contents.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Tag html = new Tag("html");
            foreach(ReportComponent component in _content)
            {
                html.AddContent(component.ToHtml());
            }
            return html.ToString();
        }

        #endregion Methods

    }
}
