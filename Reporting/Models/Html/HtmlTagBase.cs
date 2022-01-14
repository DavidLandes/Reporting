using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

namespace Reporting.Models.Html
{
    /*  HTML terms:
     *  <tag attribute="property" attribute="property: value;"></tag>
     */

    [XmlInclude(typeof(Tag))]
    public class HtmlTagBase
    {
        #region Fields

        public string _tag = "div";
        public HtmlAttributes _attributes = new HtmlAttributes();
        public StyleAttributes _styles = new StyleAttributes();
        public List<object> _content = new List<object>();

        #endregion Fields

        #region Constructors

        public HtmlTagBase()
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds a generic html attribute to the tag. If the attribute exists, it will be overwritten.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        public void AddAttribute(string attribute, string value)
        {
            if (attribute.Trim().Equals("style"))
            {
                throw new Exception("Error: Tried to set a CSS style as an attribute. Perhaps AddStyle() is what you want?");
            }    
            _attributes.Set(attribute, value);
        }

        /// <summary>
        /// Adds a CSS style to this tag. If the property exists, it will be overwritten.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public void AddStyle(string property, string value)
        {
            _styles.Set(property, value);
        }

        /// <summary>
        /// Add another tag to the content of this element. 
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(HtmlTagBase content)
        {
            _content.Add(content);
        }

        /// <summary>
        /// Add text to the content of this element.
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(string content)
        {
            _content.Add(content);
        }

        /// <summary>
        /// Clear all contents of this element.
        /// </summary>
        public void ClearContent()
        {
            _content.Clear();
        }

        /// <summary>
        /// Parse the attributes of this tag into a string.
        /// </summary>
        private string ParseAttributes()
        {
            return _attributes.ToString();
        }

        /// <summary>
        /// Parse the css properties of this tag into an string.
        /// </summary>
        /// <returns></returns>
        private string ParseStyles()
        {
            return _styles.ToString();
        }

        /// <summary>
        /// Generate tabs for indentation.
        /// </summary>
        /// <param name="depth">The level of depth in the html tree</param>
        /// <returns>The string indentation for this depth level in the html tree</returns>
        private string GetIndent(int depth)
        {
            string indent = "";

            for (int i = 0; i < depth; i++)
            {
                indent += "\t";
            }
            return indent;
        }

        /// <summary>
        /// Recursively parse this tag into an html tree.
        /// </summary>
        /// <param name="depth">The level of depth in the html tree</param>
        /// <param name="root">The html tag at the base of this tree</param>
        /// <returns>The string version of this tag's html tree</returns>
        private string ParseHtml(HtmlTagBase root, int depth)
        {
            string attributes = root.ParseAttributes();
            string attributeSeparator = string.IsNullOrWhiteSpace(attributes) ? "" : " ";
            string styles = root.ParseStyles();
            string styleSeparator = string.IsNullOrWhiteSpace(styles) ? "" : " ";


            string indent = GetIndent(depth);
            string contIndent = GetIndent(depth+1);

            string contentHtml = "";
            // Parse this tag's content.
            foreach (object child in root._content)
            {
                // This child is another Html tag. Parse it into a string..
                if (child is HtmlTagBase)
                {
                    contentHtml += $"\n{ParseHtml((child as HtmlTagBase), depth+1)}";
                }
                // This child is just a string. Add it to the content.
                else if (child is String)
                {
                    contentHtml += $"\n{contIndent}{child}";
                }
            }

            // Return the parsed html tag & its content.
            return $"{indent}<{root._tag}{attributeSeparator}{attributes}{styleSeparator}{styles}>" +
                       contentHtml + "\n" +
                   $"{indent}</{root._tag}>";
        }

        /// <summary>
        /// Represents this html tag as a string.
        /// </summary>
        /// <returns>This tag as an html tree</returns>
        public override string ToString()
        {
            return ParseHtml(this, 0);
        }

        /// <summary>
        /// Compare another tag to this one to determine if they have the same value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is HtmlTagBase))
                return false;

            HtmlTagBase other = obj as HtmlTagBase;
            return ToString().Equals(other);
        }

        #endregion Methods
    }
}
