
using Reporting.Models.ReportComponents;
using System;
using System.Diagnostics;
using System.IO;

namespace Reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();

            Table t = new Table("ProductID", "Weight", "Quantity");
            for (int i = 0; i < 25; i++)
            {
                Random r = new Random();
                t.AddRow(r.Next(610, 627).ToString(), Math.Round((r.NextDouble() * 100.0), 2).ToString(), r.Next(1, 5).ToString());
            }

            HeadingText title = new HeadingText("Bowman and Landes Turkeys Inc.", 1);
            Text address = new Text("6490 Ross Rd. New Carlisle, OH 45344");
            Text phone = new Text("(937) 845-9466");
            Column co = new Column(title, address, phone, t);
            report.Add(co);


            ReportParser rp = new ReportParser();
            rp.SerializePage(report, rp.ReportsDirectory + "test-template.xml");
            Report p = rp.DeserializePage(rp.ReportsDirectory + "test-template.xml");


            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            Console.WriteLine($"writing {OUT_FILE}");
            File.WriteAllText(OUT_FILE, p.ToString());
        }
    }
}
