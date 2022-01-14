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
        public HtmlAttribute _attributes = new HtmlAttribute();
        public List<object> _content = new List<object>();

        #endregion Fields

        #region Constructors

        public HtmlTagBase()
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds an html attribute to the tag. "style" attributes can added more than once, but other attributes don't support that
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        virtual public void AddAttribute(string attribute, string value)
        {
            if (_attributes.Contains(attribute))
            {
                // Allow new style values to be appended to an existing style. 
                if (attribute == "style")
                {
                    string currentStyle = _attributes.Get(attribute);

                    // There are no current style properties, so just add the new ones in.
                    if (currentStyle == string.Empty && value != string.Empty)
                    {
                        // Remove attribute to make room for updated version.
                        _attributes.Remove("style");
                    }
                    else
                    {
                        // Remove any duplicate properties & add the rest of the values into the style attribute.
                        HandleDuplicateStyleProperties(currentStyle, value);
                        return;
                    }
                }
                // This is not a style attribute & cannot contain multiple values.
                else { 
                    Debug.WriteLine($"Error: Tried to add duplicate attribute \'{attribute}\' on tag \'{_tag}\'");
                    return;
                }
            }
            _attributes.Set(attribute, value);
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
        /// Adds new HTML style properties to the current style attribute if they are not duplicates.
        /// </summary>
        /// <param name="currentStyles"></param>
        /// <param name="newStyles"></param>
        /// <returns></returns>
        private void HandleDuplicateStyleProperties(string currentStyles, string newStyles)
        {
            // Both contain styles.
            if (currentStyles != string.Empty && newStyles != string.Empty)
            {
                // Parse out each property Ex: "property: value;"
                IEnumerable<string> currentStyleProperties = currentStyles.Split(';').Where(item => item != string.Empty);
                IEnumerable<string> newStyleProperties = newStyles.Split(';').Where(item => item != string.Empty);

                // Append all non-duplicate properties.
                string joinedProperties = currentStyles;
                for (int x = 0; x < newStyleProperties.Count(); x++)
                {
                    string newProp = newStyleProperties.ElementAt(x).Split(":")[0].Trim();
                    bool matchFound = currentStyleProperties.Where(current => current.Split(":")[0].Trim() == newProp).Count() > 0;

                    // Trying to add an empty element. skip.
                    if (newStyleProperties.ElementAt(x).Trim() == string.Empty)
                        continue;

                    if (!matchFound)
                        joinedProperties += $" {newStyleProperties.ElementAt(x)};";
                    else
                        Debug.WriteLine($"Warning: Tried to add duplicate style property \'{newProp}\' on tag \'{_tag}\'");
                }
                // Update the new value to the current style.
                _attributes.Remove("style");
                _attributes.Set("style", joinedProperties);
            }
        }

        /// <summary>
        /// Parse the attributes of this tag into a html string.
        /// </summary>
        private string ParseAttributes()
        {
            return _attributes.ToString();
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
            return $"{indent}<{root._tag}{attributeSeparator}{attributes}>" +
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
