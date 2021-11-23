using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Models.Html
{
    class BodySection : HtmlTagBase
    {
        BodySection()
        {
            _tag = "body";
        }

        #region Methods

        /// <summary>
        /// Add another tag to the content of this element. 
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(HtmlTagBase content)
        {
            _content.Add(content);
        }

        #endregion Methods
    }
}
