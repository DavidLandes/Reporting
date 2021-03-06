using ReportDesigner.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ReportDesigner.Views
{
    public sealed partial class Workbench : UserControl
    {
        #region Properties

        WorkbenchViewModel vm = new WorkbenchViewModel();

        #endregion Properties

        #region Constructors

        public Workbench()
        {
            this.DataContext = vm;
            this.InitializeComponent();
            HtmlViewer.Navigate(new Uri($"ms-appx-web:///{vm.TemplateSource}"));
        }

        #endregion Constructors
    }
}
