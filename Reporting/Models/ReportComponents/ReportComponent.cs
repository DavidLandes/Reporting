using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public abstract class ReportComponent
    {
        #region Methods

        /// <summary>
        /// Convert this report component into its html building block.  
        /// </summary>
        /// <returns></returns>
        public abstract Tag ToHtml();

        #endregion Methods
    }
}
