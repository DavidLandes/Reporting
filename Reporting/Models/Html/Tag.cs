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
    }
}
