﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    class Table : HtmlTagBase
    {
        #region Fields

        private int _columnCount;
        public string[] _rowHeaders;
        private string _width = "90%";
        private string _rowHeight = "40px";

        #endregion Fields

        #region Constructors

        public Table(string[] headers)
        {
            _columnCount = headers.Length;
            _rowHeaders = headers;
            _tag = "table";

            AddAttribute("style", $"border-collapse: collapse; width: {_width}; margin: 0 auto;");
            InsertHeaderRow();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Add the header row to the table.
        /// </summary>
        public void InsertHeaderRow()
        {
            Tag row = new Tag("tr");
            row.AddAttribute("style", $"height: {_rowHeight}; width: {_width}; border-bottom: 2px solid black;");
            foreach (string title in _rowHeaders)
            {
                // Create header tags & add them to the row.
                Tag data = new Tag("th");
                data.AddContent(title);
                row.AddContent(data);
            }
            // Add the row tag to the table.
            AddContent(row);
        }

        /// <summary>
        /// Insert a row of values into the table.
        /// </summary>
        /// <param name="values">The list of values must have the same number of rows as the table</param>
        public void InsertRow(string[] values)
        {
            if (values.Length != _columnCount)
            {
                Console.WriteLine($"Error: cannot insert row with {values.Length} columns into a table with {_columnCount} columns.");
                return;
            }

            Tag row = new Tag("tr");
            row.AddAttribute("style", $"height: {_rowHeight};");
            foreach (string value in values)
            {
                // Create data tags & add them to the row.
                Tag data = new Tag("td");
                data.AddAttribute("style", "text-align: center;");
                data.AddContent(value);
                row.AddContent(data);
            }
            // Add the row tag to the table.
            AddContent(row);
        }

        #endregion Methods
    }
}