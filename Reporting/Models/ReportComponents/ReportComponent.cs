using Reporting.Models.Html;
using System.Collections.Generic;
using System.Diagnostics;

namespace Reporting.Models.ReportComponents
{
    public abstract class ReportComponent
    {
        #region Fields

        public List<ReportComponent> _children = new List<ReportComponent>();
        private string _id = "";
        public string _height = "";
        public string _width = "";

        #endregion Fields

        #region Enums

        /// <summary>
        /// Describes an HTML unit of measure.
        /// </summary>
        public enum Measurement
        {
            Percent,
            Px,
            Pt,
            Em
        }

        /// <summary>
        /// Convert the measurement enum into an string usable in HTML.
        /// </summary>
        /// <returns></returns>
        public string MeasurementToString(Measurement unit)
        {
            switch (unit)
            {
                case Measurement.Percent:
                    return "%";
                case Measurement.Px:
                    return "px";
                case Measurement.Pt:
                    return "pt";
                case Measurement.Em:
                    return "em";
                default:
                    Debug.WriteLine("No conversion for this measurement.");
                    return "pt";
            }
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Get/Set a unique identifier for this component. Be careful to not give components the same ID, this is not enforced & will cause unwanted behaviors.
        /// </summary>
        public string Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Get the width of this component as an HTML string.
        /// </summary>
        public string Width
        {
            get => _width;
        }

        /// <summary>
        /// Get the height of this component as an HTML string.
        /// </summary>
        public string Height
        {
            get => _height;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Set the height of this component with the given unit.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public void SetHeight(int value, Measurement unit)
        {
            _height = $"{value}{MeasurementToString(unit)}";
        }

        /// <summary>
        /// Set the width of this component with the given unit.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public void SetWidth(int value, Measurement unit)
        {
            _width = $"{value}{MeasurementToString(unit)}";
        }

        /// <summary>
        /// If this ReportComponent is designed as a container for other ReportComponents, return a reference to its list of child components. 
        /// </summary>
        /// <returns>A reference to the list of child components. Or a reference to an empty list if there are no children.</returns>
        public List<ReportComponent> ChildComponents()
        {
            return _children;
        }

        /// <summary>
        /// Convert this report component into its html building block.  
        /// </summary>
        /// <returns></returns>
        public abstract Tag ToHtml();

        #endregion Methods
    }
}
