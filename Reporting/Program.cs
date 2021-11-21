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
            Table table = new Table(new string[] { "ProductID", "Weight", "Quantity" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });
            table.InsertRow(new string[] { "615", "15.84", "2" });

            string OUT_FILE = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test-report.html";
            File.WriteAllText(OUT_FILE, table.ToString());

        }
    }
}
