using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Text : ReportComponent
    {
        #region Fields

        public string _text;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Text()
        {
            _text = "";
        }

        /// <summary>
        /// Creates a text box to be shown in a report.
        /// </summary>
        /// <param name="text"></param>
        public Text(string text)
        {
            _text = text;
        }

        #endregion Constructors

        #region Methods

        public override Tag ToHtml()
        {
            Tag html = new Tag("p");
            html.AddContent(_text);
            return html;
        }

        #endregion Methods
    }
}
