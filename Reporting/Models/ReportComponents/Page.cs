using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    public class Page : ReportComponent
    {
        /// <summary>
        /// Default constructor for xml serialization. 
        /// </summary>
        public Page()
        {

        }

        public Page(string tag)
        {
            Html = new Tag(tag);
        }

        public void AddContent(params ReportComponent[] content)
        {
            foreach(ReportComponent r in content)
            {
                Html.AddContent(r.Html);
            }
        }

    }
}
