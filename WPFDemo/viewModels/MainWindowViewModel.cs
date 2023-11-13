using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.viewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
		private bool _isLogged;

		public bool IsLogged
		{
			get { return _isLogged; }
            set { _isLogged = value; onPropChanged("IsLogged"); }
		}

        internal void Logout()
        {
            IsLogged = false;
        }
    }
}
