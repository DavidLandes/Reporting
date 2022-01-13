using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Text : ReportComponent
    {
        #region Fields

        public string _value;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Text()
        {
            _value = "";
        }

        /// <summary>
        /// Creates a text box to be shown in a report.
        /// </summary>
        /// <param name="text"></param>
        public Text(string text)
        {
            _value = text;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Set the text value to be displayed.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            _value = text;
        }

        public override Tag ToHtml()
        {
            Tag html = new Tag("p");

            // Set size.
            if (!string.IsNullOrEmpty(Height))
                html.AddAttribute("height", Height);
            if (!string.IsNullOrEmpty(Width))
                html.AddAttribute("width", Width);

            html.AddContent(_value);
            return html;
        }

        #endregion Methods
    }
}
