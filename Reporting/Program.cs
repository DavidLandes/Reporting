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
            for (int i = 0; i < 25; i++)
            {
                Random r = new Random();
                table.InsertRow(r.Next(610, 627).ToString(), Math.Round((r.NextDouble()*100.0), 2).ToString(), r.Next(1, 5).ToString());
            }

            HeaderText title = new HeaderText("Bowman and Landes Turkeys Inc.", 1);
            Text address = new Text("6490 Ross Rd. New Carlisle, OH 45344");
            Text phone = new Text("(937) 845-9466");

            Row row = new Row(title);
            Row row2 = new Row(address);
            Row row3 = new Row(phone);
            Column headColumn = new Column(row, row2, row3);

            html.AddContent(headColumn);
            html.AddContent(table);

            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            File.WriteAllText(OUT_FILE, html.ToString());
        }
    }
}
