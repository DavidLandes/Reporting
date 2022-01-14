using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Reporting.Models.Html;
using Reporting.Models.ReportComponents;

namespace Reporting
{
    // TODO: Add report headers/footers. Need some to be on every page, and others to be only on first/last pages.
    /// <summary>
    /// Gives ReportComponents structure and generates HTML for a report. Can be serialized into files with ReportParser.
    /// </summary>
    [XmlInclude(typeof(Column))]
    [XmlInclude(typeof(HeadingText))]
    [XmlInclude(typeof(Row))]
    [XmlInclude(typeof(Table))]
    [XmlInclude(typeof(Text))]
    [XmlInclude(typeof(Image))]
    public class Report
    {

        #region Fields

        public List<ReportComponent> _content;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
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
        /// Return the content ReportComponents as a list.
        /// </summary>
        /// <returns></returns>
        public List<ReportComponent> Content()
        {
            return _content;
        }

        /// <summary>
        /// Find a child component with the given ID & return it. Searching for null or whitespace Ids always returns null. However, whitespace in between characters is allowed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A child component of this report, or null if the ID was not found.</returns>
        public ReportComponent FindById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            // Search the content list.
            foreach (ReportComponent child in _content)
            {
                ReportComponent component = FindById_Helper(id, child);
                if (component != null)
                    return component;
            }

            Debug.WriteLine($"Could not find a ReportComponent with id: {id}");
            return null;
        }

        /// <summary>
        /// Recursive helper method for finding a component with the given ID. Pre-order traversal.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private ReportComponent FindById_Helper(string id, ReportComponent node)
        {
            // Is this the one?
            if (node.Id.Equals(id))
            {
                return node;
            }

            // Check the child nodes..
            if (node.ChildComponents().Count > 0)
            {
                foreach (ReportComponent child in node.ChildComponents())
                {
                    ReportComponent match = FindById_Helper(id, child);
                    if (match != null)
                        return match;
                    else
                        continue;
                }
            }

            // Base Case. Nothing found.
            return null;
        }

        /// <summary>
        /// Return a list of all ReportComponent ID strings.
        /// </summary>
        /// <returns></returns>
        public List<string> GetIds()
        {
            return GetIds_Helper(_content);
        }

        /// <summary>
        /// Recursive helper for GetIds().  
        /// </summary>
        /// <param name="componentList"></param>
        /// <returns>A list of all Ids.</returns>
        private List<string> GetIds_Helper(List<ReportComponent> componentList)
        {
            List<string> ids = new List<string>();

            // Search the content list.
            foreach (ReportComponent child in componentList)
            {
                if (!string.IsNullOrWhiteSpace(child.Id))
                    ids.Add(child.Id);
                if (child.ChildComponents().Count > 0)
                    ids.AddRange(GetIds_Helper(child.ChildComponents()));
            }
            return ids;
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
