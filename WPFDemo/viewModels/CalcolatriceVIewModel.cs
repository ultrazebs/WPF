using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.viewModels
{
    internal class CalcolatriceVIewModel : INotifyPropertyChanged
    {

        private string _result = "0";
        public string result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("result"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void tasto(string t)
        {
            result += t;
        }
    }
}
