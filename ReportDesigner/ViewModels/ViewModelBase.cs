using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDesigner.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Event notifies when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Properties

        #region EventHandlers

        /// <summary>
        /// Emits a property changed event for the given property.
        /// </summary>
        /// <param name="property"></param>
        protected void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(property);
                handler(this, e);
            }
        }

        #endregion EventHandlers
    }
}
