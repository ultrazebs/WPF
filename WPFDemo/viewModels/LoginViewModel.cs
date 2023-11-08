using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.viewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        private string _username;

        public string username
        {
            get { return _username; }
            set { _username = value; onPropChanged("username"); }
        }


        public LoginViewModel() { }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
