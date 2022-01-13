using System;
using System.Collections.Generic;
using System.Diagnostics;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class HeadingText : ReportComponent
    {
        #region Fields

        public string _value;
        private int _size;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public HeadingText()
        {
            _value = "";
            _size = 1;
        }

        /// <summary>
        /// Creates a heading with the given text and the heading size.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="headingSize"></param>
        public HeadingText(string text, int headingSize)
        {
            SetText(text);
            SetHeadingSize(headingSize);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Set the heading font size. Valid sizes correspond to html guidelines, a number 1-6.
        /// </summary>
        /// <param name="size"></param>
        public void SetHeadingSize(int size)
        {
            if (size < 1 || size > 6)
            {
                Debug.WriteLine($"HeaderText size \'{size}\' invalid. Must be a valid html heading size (1-6). Defaulting to <h1>");
                _size = 1;
            }
            else
            {
                _size = size;
            }
        }

        /// <summary>
        /// Set the heading text.
        /// </summary>
        public void SetText(string text)
        {
            _value = text;
        }

        public override Tag ToHtml()
        {
            Tag html = new Tag($"h{_size}");

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
