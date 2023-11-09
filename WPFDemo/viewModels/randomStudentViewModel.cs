using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Controllers;
using WPFDemo.Models;

namespace WPFDemo.viewModels
{
    internal class randomStudentViewModel : BaseViewModel
    {

        private Student _studente;
        public Student Studente
        {

            get { return _studente; }
            set { _studente = value; onPropChanged("Studente"); }
        }



        public void generateRandom()
        {
            Studente = StudentController.generateRandom();
        }

        public randomStudentViewModel() { }

	}
}
