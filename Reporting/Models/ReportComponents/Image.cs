using Reporting.Models.Html;
using System.IO;

namespace Reporting.Models.ReportComponents
{
    public class Image : ReportComponent
    {
        #region Fields

        public string _imageSource = "";
        public string _alternateText = "Image";
        public string _height = "";
        public string _width = "";

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Image()
        {

        }

        /// <summary>
        /// Create an image that can be used in a Report.
        /// </summary>
        public Image(string source, string alternateText)
        {
            SetSource(source);
            SetAlternateText(alternateText);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Set the height and width of the image, using html size format. Ex: "100px", "15%", etc..
        /// </summary>
        public void SetSize(string height, string width)
        {
            _height = height;
            _width = width;
        }

        /// <summary>
        /// Set the filepath to this image.
        /// </summary>
        /// <param name="source"></param>
        public void SetSource(string source)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"Tried to create an Image with an invalid source: {source}");
            }
            else
            {
                _imageSource = source;
            }
        }

        /// <summary>
        /// Sets the text HTML should display if the image cannot be loaded.
        /// </summary>
        /// <param name="text"></param>
        public void SetAlternateText(string text)
        {
            _alternateText = text;
        }

        public override Tag ToHtml()
        {
            Tag html = new Tag("img");
            html.AddAttribute("src", "file:///" + _imageSource);
            html.AddAttribute("alt", _alternateText);

            // If height/width are not defined, the image will be displayed as its actual size.
            if (!string.IsNullOrEmpty(_height))
                html.AddAttribute("height", _height);
            if (!string.IsNullOrEmpty(_width))
                html.AddAttribute("width", _width);

            return html;
        }

        #endregion Methods
    }
}
