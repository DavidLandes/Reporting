using System;
using System.IO;
using System.Xml.Serialization;

namespace Reporting
{
    class ReportParser
    {
        #region Fields

        public readonly string ReportsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//";
        XmlSerializer _serializer = new XmlSerializer(typeof(Report));

        #endregion Fields

        #region Properties


        #endregion Properties

        #region Exceptions

        public class SerializeException : Exception
        {
            public SerializeException(string message) : base(message) { }
        }

        #endregion Exceptions

        #region Constructors

        public ReportParser()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Serialize a page into an xml format, then write to the given file.
        /// </summary>
        /// <param name="report"></param>
        public void SerializePage(Report report, string filePath)
        {
            try
            {
                using (FileStream file = File.Create(filePath))
                {
                    _serializer.Serialize(file, report);
                }
            }
            catch(Exception e)
            {
                throw new SerializeException("Serialize Error: " + e);
            }
        }

        /// <summary>
        /// Deserialize a xml class from the given file and parse it into a page.
        /// </summary>
        /// <returns></returns>
        public Report? DeserializePage(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return null;

                using (FileStream file = File.OpenRead(filePath))
                {
                    return (Report)_serializer.Deserialize(file);
                }
            }
            catch(Exception e)
            {
                throw new SerializeException("Serialize Error: " + e);
            }
        }

        #endregion Methods
    }
}
