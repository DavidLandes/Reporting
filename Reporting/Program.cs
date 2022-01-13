
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

            Table t = new Table();                          t.Id = "coolTable";
            HeadingText title = new HeadingText();          title.Id = "heading";
            Text address = new Text();                      address.Id = "addr";
            Text phone = new Text();                        phone.Id = "phone#";
            Image im = new Image();                         im.Id = "icon";
            Column co = new Column(title, address, phone);  co.Id = "contentColumn";
            Row roo = new Row(co, im);                      roo.Id = "contentRow";

            Text footer = new Text();                       footer.Id = "footer";
            Row footRow = new Row(footer);                  footRow.Id = "footRow";

            report.Add(roo);
            report.Add(t);
            report.Add(footRow);


            // Saving the template...
            ReportParser.SerializeReport(report, ReportParser.ReportsDirectory + "test-template.xml");


            // Opening the template report...
            Report p = ReportParser.DeserializeReport(ReportParser.ReportsDirectory + "test-template.xml");


            // Add data to template report...
            p.FindById("contentColumn").SetWidth(100, ReportComponent.Measurement.Percent);
            p.FindById("contentRow").SetWidth(100, ReportComponent.Measurement.Percent);

            (p.FindById("heading") as HeadingText).SetText("Bowman and Landes Turkeys, Inc.");
            (p.FindById("addr") as Text).SetText("6490 Ross Rd, New Carlisle, OH 45344");
            (p.FindById("phone#") as Text).SetText("(937) 845-9466");
            (p.FindById("footer") as Text).SetText("Copyright 2022");
            p.FindById("footRow").SetWidth(100, ReportComponent.Measurement.Percent);

            (p.FindById("icon") as Image).SetSource(ICON_PATH);
            p.FindById("icon").SetWidth(50, ReportComponent.Measurement.Px);
            p.FindById("icon").SetHeight(50, ReportComponent.Measurement.Px);

            p.FindById("coolTable").SetWidth(70, ReportComponent.Measurement.Percent);
            p.FindById("coolTable").SetHeight(1000, ReportComponent.Measurement.Px);
            (p.FindById("coolTable") as Table).SetHeaderRow("ProductID", "Weight", "Quantity");

            // Generating some test data for the table...
            for (int i = 0; i < 25; i++)
            {
                Random r = new Random();
                (p.FindById("coolTable") as Table).AddRow(r.Next(610, 627).ToString(), Math.Round((r.NextDouble() * 100.0), 2).ToString(), r.Next(1, 5).ToString());
            }


            // Writing the complete report to an html file...
            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            Debug.WriteLine($"writing {OUT_FILE}");
            File.WriteAllText(OUT_FILE, p.ToString());
        }
    }
}
