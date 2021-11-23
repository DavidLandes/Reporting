using Reporting.Models;
using Reporting.Models.Html;
using Reporting.Models.ReportComponents;
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

            HeaderText title = new HeaderText("Bowman and Landes Turkeys Inc.", 1);
            Text address = new Text("6490 Ross Rd. New Carlisle, OH 45344");
            Text phone = new Text("(937) 845-9466");

            Row row = new Row("90%", title, title);
            Row row2 = new Row("90%", address);
            Row row3 = new Row("90%", phone);
            Column headColumn = new Column("90%", row, row2, row3);

            html.AddContent(headColumn);
            html.AddContent(table);

            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            File.WriteAllText(OUT_FILE, html.ToString());

        }
    }
}
