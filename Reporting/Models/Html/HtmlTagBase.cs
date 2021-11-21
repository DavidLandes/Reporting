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
        protected string _content = "";
        protected List<Tag> _children = new List<Tag>();
        // Useful for pretty formatting. Using a tree structure, we can edit this property to get the proper nested indentation for all elements.
        public int _treeDepth = 0;


        #endregion Fields

        #region Methods

        /// <summary>
        /// Adds an html attribute to the tag.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        public void AddAttribute(string attribute, string value)
        {
            if (_attributes.ContainsKey(attribute))
            {
                Console.WriteLine($"Error: Tried to add duplicate attribute \'{attribute}\' on tag \'{_tag}\'");
                return;
            }
            _attributes.Add(attribute, value);
        }

        /// <summary>
        /// Add another tag to the content of this element. Also keep track of the child tags separately by placing them into a list.
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(Tag content)
        {
            _children.Add(content);
            _content += content.ToString();
        }

        /// <summary>
        /// Add text to the content of this element.
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(string content)
        {
            _content += content;
        }

        /// <summary>
        /// Parse the attributes of this tag into a html string.
        /// </summary>
        protected string ParseAttributes()
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
        /// Parse the children of this tag into a html string.
        /// </summary>
        protected string ParseChildren()
        {
            string res = "";
            foreach (Tag child in _children)
            {
                res += child.ToString();
            }
            return res;
        }

        /// <summary>
        /// Generate tabs for indentation.
        /// </summary>
        /// <param name="isContent"></param>
        /// <returns></returns>
        protected string GetIndentLevel(bool isContent = false)
        {
            int depth = isContent ? _treeDepth + 1 : _treeDepth;
            string indent = "";

            for (int i = 0; i < depth; i++)
            {
                indent += "\t";
            }
            return indent;
        }

        /// <summary>
        /// Parse this tag into html.
        /// </summary>
        public override string ToString()
        {
            string attributes = ParseAttributes();
            string indent = GetIndentLevel();
            string contIndent = GetIndentLevel(true);

            return $"{indent}<{_tag}{attributes}>\n{contIndent}{_content}\n{indent}</{_tag}>\n";
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
