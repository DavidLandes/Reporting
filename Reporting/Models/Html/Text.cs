using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.Html
{
    class Text : HtmlTagBase
    {
        #region Fields


        #endregion Fields

        #region Constructors

        public Text(string text)
        {
            _tag = "p";
            _content.Add(text);
        }

        #endregion Constructors

        #region Methods


        #endregion Methods
    }
}
