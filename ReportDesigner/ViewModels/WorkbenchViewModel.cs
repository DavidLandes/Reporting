using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ReportDesigner.ViewModels
{
    public class WorkbenchViewModel : ViewModelBase
    {
        #region Fields

        private string _templateSource;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The URL to the report being built. This file contains the HTML that is shown in the workbench.
        /// </summary>
        public string TemplateSource
        {
            get { return _templateSource; }
            set 
            {
                _templateSource = value;
                OnPropertyChanged("TemplateSource");
            }
        }

        #endregion Properties

        #region Constructors

        public WorkbenchViewModel()
        {
            TemplateSource = "Assets/report.html";
        }

        #endregion Constructors
    }
}
