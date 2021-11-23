using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    class Tag : HtmlTagBase
    {
        #region Constructors

        public Tag(string name)
        {
            _tag = name;
        }

        #endregion Constructors

        #region Methods

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

        #endregion Methods
    }
}
