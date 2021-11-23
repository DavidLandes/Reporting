using Reporting.Models;
using Reporting.Models.Html;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            Tag html = new Tag("html");

            Table table = new Table("ProductID", "Weight", "Quantity");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");
            table.InsertRow("615", "15.84", "2");

            HeaderText h1 = new HeaderText("Header 1", 1);
            HeaderText h2 = new HeaderText("Header 2", 2);
            Row row = new Row("90%", h1, h2);
            Row row2 = new Row("90%", h1, h2, row);

            html.AddContent(h1);
            html.AddContent(row);
            html.AddContent(row2);
            html.AddContent(table);

            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            File.WriteAllText(OUT_FILE, html.ToString());

        }
    }
}
