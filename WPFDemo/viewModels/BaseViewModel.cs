using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.viewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropChanged(string field)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(field));
        }
    }
}
