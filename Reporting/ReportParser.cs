using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Reporting.Models.Html;
using Reporting.Models.ReportComponents;

namespace Reporting
{
    class ReportParser
    {
        #region Fields

        string _reportsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//";

        #endregion Fields

        #region Properties


        #endregion Properties

        #region Constructors

        public ReportParser()
        {
        }

        #endregion Constructors

        #region Methods

        public void Serialize(Page report)
        {
            XmlSerializer serializer = new XmlSerializer(report.GetType());
            Debug.WriteLine("Writing directory: " + _reportsDirectory + "test-template.xml");
            using (FileStream file = File.Create(_reportsDirectory + "test-template.xml"))
            {
                serializer.Serialize(file, report);
            }

            //  File.WriteAllText(_reportsDirectory + "test-template.xml", content);
            Console.ReadLine();
        }

        #endregion Methods
    }
}
