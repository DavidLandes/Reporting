
using Reporting.Models.ReportComponents;
using System;
using System.Diagnostics;
using System.IO;

namespace Reporting
{
    // TODO: all classes have some public properties that should be private, to allow XML serialization.. This is a bad work-around.. 
    class Program
    {
        static void Main(string[] args)
        {
            string ICON_PATH = "C:/Users/David/Pictures/Saved Pictures/chicago.jpg";

            // Creating a custom report template...
            Report report = new Report();

            Table t = new Table();
            HeadingText title = new HeadingText();
            Text address = new Text();
            Text phone = new Text();
            Image im = new Image();
            Column co = new Column(title, address, phone);
            Row roo = new Row(co, im);
            report.Add(roo);
            report.Add(t);


            // Saving the template...
            ReportParser.SerializeReport(report, ReportParser.ReportsDirectory + "test-template.xml");


            // Opening the template report...
            Report p = ReportParser.DeserializeReport(ReportParser.ReportsDirectory + "test-template.xml");


            // Add data to template report...
            (((p._content[0] as Row)._children[0] as Column)._children[0] as HeadingText).SetText("Bowman and Landes Turkeys, Inc.");
            (((p._content[0] as Row)._children[0] as Column)._children[1] as Text).SetText("6490 Ross Rd, New Carlisle, OH 45344");
            (((p._content[0] as Row)._children[0] as Column)._children[2] as Text).SetText("(937) 845-9466");

            ((p._content[0] as Row)._children[1] as Image).SetSource(ICON_PATH);
            ((p._content[0] as Row)._children[1] as Image).SetSize("100px", "100px");

            (p._content[1] as Table).SetHeaderRow("ProductID", "Weight", "Quantity");

            // Generating some test data for the table...
            for (int i = 0; i < 25; i++)
            {
                Random r = new Random();
                (p._content[1] as Table).AddRow(r.Next(610, 627).ToString(), Math.Round((r.NextDouble() * 100.0), 2).ToString(), r.Next(1, 5).ToString());
            }


            // Writing the complete report to an html file...
            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            Console.WriteLine($"writing {OUT_FILE}");
            File.WriteAllText(OUT_FILE, p.ToString());
        }
    }
}
