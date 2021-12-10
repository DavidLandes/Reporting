
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
            //   Tag html = new Tag("html");
            Page report = new Page();

            Table table = new Table("ProductID", "Weight", "Quantity");
            for (int i = 0; i < 25; i++)
            {
                Random r = new Random();
                table.InsertRow(r.Next(610, 627).ToString(), Math.Round((r.NextDouble()*100.0), 2).ToString(), r.Next(1, 5).ToString());
            }

            HeadingText title = new HeadingText("Bowman and Landes Turkeys Inc.", 1);
            Text address = new Text("6490 Ross Rd. New Carlisle, OH 45344");
            Text phone = new Text("(937) 845-9466");

            Column co = new Column(title, address, phone, table);

            report.AddContent(co);


            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            File.WriteAllText(OUT_FILE, report.ToString());
        }
    }
}
