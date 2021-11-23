using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    class HtmlTagBase
    {
        #region Fields

        protected string _tag = "div";
        protected Dictionary<string, string> _attributes = new Dictionary<string, string>();
        protected List<object> _content = new List<object>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Adds an html attribute to the tag.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        virtual public void AddAttribute(string attribute, string value)
        {
            if (_attributes.ContainsKey(attribute))
            {
                Console.WriteLine($"Error: Tried to add duplicate attribute \'{attribute}\' on tag \'{_tag}\'");
                return;
            }
            _attributes.Add(attribute, value);
        }

        /// <summary>
        /// Parse the attributes of this tag into a html string.
        /// </summary>
        private string ParseAttributes()
        {
            string res = "";
            foreach (string attr in _attributes.Keys)
            {
                string value = "";

                // Get the value of this attribute. If something goes wrong, just skip & move on.
                if (!_attributes.TryGetValue(attr, out value))
                    continue;

                res += $" {attr}=\"{value}\"";
            }
            return res;
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
            return $"{indent}<{root._tag}{attributes}>" +
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
