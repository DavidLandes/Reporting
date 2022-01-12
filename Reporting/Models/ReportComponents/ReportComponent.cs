using Reporting.Models.Html;
using System.Collections.Generic;

namespace Reporting.Models.ReportComponents
{
    public abstract class ReportComponent
    {
        #region Fields

        public List<ReportComponent> _children = new List<ReportComponent>();
        private string _id;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Get/Set a unique identifier for this component. Be careful to not give components the same ID, this is not enforced & will cause unwanted behaviors.
        /// </summary>
        public string Id
        {
            get => _id;
            set => _id = value;
        }

        #endregion Properties

        #region Methods

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
