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
		private Student _selectedStudent;

		public Student selectedStudent
        {
			get { return _selectedStudent; }
			set { _selectedStudent = value; onPropChanged("selectedStudent"); onPropChanged("delEnabled"); }
        }


		private string _filter;

		public string filter
		{
			get { return _filter; }
			set { _filter = value; onPropChanged("filter"); Filter(); }
		}

		private bool _delEnabled;

		public bool delEnabled
        {
			get { return !(selectedStudent==null); }
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

		public void deleteStudent()
		{
            if (selectedStudent != null)
            {
				StudentController.deleteStudent(selectedStudent);
				

                // resetting variables
                filter = "";
				selectedStudent = null;

				// resetting view
				Filter();
            }
			
        }

		public void newStudent()
		{
			StudentManagerView view = new StudentManagerView("Create Student");
			
			Filter();
		}

        public void updateStudent()
        {
			if (selectedStudent != null)
			{
				StudentManagerView view = new StudentManagerView(selectedStudent, "Update Student");
				Filter();
			}
            
        }
    }
}
