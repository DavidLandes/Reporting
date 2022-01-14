using System.Collections.Generic;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Table : ReportComponent
    {
        #region Fields

        public List<string> _columnHeaders;
        public List<List<string>> _data;
        public string _rowHeight = "40px";

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public Table()
        {
            _columnHeaders = new List<string>();
            _data = new List<List<string>>();
        }

        /// <summary>
        /// Creates a table of string data.
        /// </summary>
        /// <param name="headers">Column headers to be displayed at the start of the table</param>
        public Table(params string[] headers)
        {
            _columnHeaders = new List<string>(headers);
            _data = new List<List<string>>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Replace the current header row to a new list of column titles.
        /// </summary>
        /// <param name="row"></param>
        public void SetHeaderRow(params string[] row)
        {
            _columnHeaders.Clear();
            _columnHeaders = new List<string>(row);
        }

        /// <summary>
        /// Replace the stored data with new list of data rows.
        /// </summary>
        /// <param name="newData"></param>
        public void SetData(List<List<string>> newData)
        {
            _data.Clear();
            _data = new List<List<string>>(newData);
        }

        /// <summary>
        /// Insert a row of data into the column.
        /// </summary>
        public void InsertRow(int index, params string[] row)
        {
            _data.Insert(index, new List<string>(row));
        }

        /// <summary>
        /// Add a row of data to the end of the table.
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(params string[] row)
        {
            _data.Add(new List<string>(row));
        }
        
        public override Tag ToHtml()
        {
            Tag html = new Tag("table");
            // Style the table.
            html.AddAttribute("style", $"border-collapse: collapse; margin: 0 auto;");

            // Set size.
            if (!string.IsNullOrWhiteSpace(Height))
                html.AddAttribute("height", Height);
            if (!string.IsNullOrWhiteSpace(Width))
                html.AddAttribute("width", Width);

            // Add all the content.
            html.AddContent(GetHeaderHtml());
            foreach(List<string> row in _data)
            {
                html.AddContent(GetRowHtml(row));
            }
            return html;
        }

        /// <summary>
        /// Generate the html for the header row.
        /// </summary>
        private Tag GetHeaderHtml()
        {
            Tag row = new Tag("tr");
            row.AddAttribute("style", $"height: {_rowHeight}; width: 100%; border-bottom: 2px solid black;");
            foreach (string title in _columnHeaders)
            {
                // Create header tags & add them to the row.
                Tag data = new Tag("th");
                data.AddContent(title);
                row.AddContent(data);
            }
            return row;
        }

        /// <summary>
        /// Generate html for a table data row.
        /// </summary>
        private Tag GetRowHtml(List<string> values)
        {
            Tag row = new Tag("tr");
            row.AddAttribute("style", $"height: {_rowHeight}; width: 100%;");
            foreach (string value in values)
            {
                // Create data tags & add them to the row.
                Tag data = new Tag("td");
                data.AddAttribute("style", "text-align: center;");
                data.AddContent(value);
                row.AddContent(data);
            }
            return row;
        }


        #endregion Methods
    }
}
