using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Command
{
    public class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        //ObservableObject
        //BaseNotify
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                //handler(this, new PropertyChangedEventArgs(null));
            }

        }
        #endregion
    }
}
