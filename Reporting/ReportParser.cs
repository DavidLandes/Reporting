using System;
using System.IO;
using System.Xml.Serialization;

namespace Reporting
{
    /// <summary>
    /// Serializes & De-serializes Report objects. Allows Reports or Report templates to be saved in a file & reloaded into an application instance when necessary.
    /// </summary>
    static class ReportParser
    {
        #region Fields

        public static readonly string ReportsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//";
        private static XmlSerializer _serializer = new XmlSerializer(typeof(Report));

        #endregion Fields

        #region Exceptions

        public class SerializeException : Exception
        {
            public SerializeException(string message) : base(message) { }
        }

        #endregion Exceptions

        #region Methods

        /// <summary>
        /// Serialize a report into an xml format, then write to the given file.
        /// </summary>
        /// <param name="report"></param>
        public static void SerializeReport(Report report, string filePath)
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
        /// Deserialize a xml class from the given file and parse it into a report.
        /// </summary>
        /// <returns></returns>
        public static Report DeserializeReport(string filePath)
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
