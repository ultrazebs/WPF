using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Controllers;
using WPFDemo.Models;

namespace WPFDemo.viewModels
{
    public class StudentViewModel : BaseViewModel
    {
		private string _filter;

		public string filter
		{
			get { return _filter; }
			set { _filter = value; onPropChanged("filter"); }
		}



		// creo una lista di oggetti di classe Student
		private List<Student> _students;
		public List<Student> Students {  
			set { _students = value; onPropChanged("Students"); }
			get { return _students; }
		}

        public StudentViewModel()
        {
			//	this.Filter(); -> da errore perché sta ancora costruendo l'interfaccia
			_students = StudentController.getStudents(filter);
        }

        // filter method
        public void Filter()
		{
			Students = StudentController.getStudents(filter);
		}

	}
}
