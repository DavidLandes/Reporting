using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Models.Html;

namespace Reporting.Models.ReportComponents
{
    class Page : ReportComponent
    {

        public Page()
        {
            Html = new Tag("html");
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
