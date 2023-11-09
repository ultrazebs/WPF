using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Controllers;
using WPFDemo.Models;

namespace WPFDemo.viewModels
{
    public class StudentManagerViewModel : BaseViewModel
    {
        private bool isNew;

        private Student _student;

        public Student Student
        {
            get { return _student; }
            set { _student = value; onPropChanged("Student"); }
        }

        

        private List<Corso> _corsi;

        public List<Corso> Corsi
        {
            get { return _corsi; }
            set { _corsi = value; onPropChanged("Corsi"); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }



        public StudentManagerViewModel()
        {
            _student = new Student(DateTime.Today);
            _corsi = CorsiController.getAll();
            isNew = true;
        }

        public StudentManagerViewModel(Student s)
        {
            _student = new Student(DateTime.Today);
            _corsi = CorsiController.getAll();
            isNew = false;
        }
        public StudentManagerViewModel(string title)
        {
            _student = new Student(DateTime.Today);
            _corsi = CorsiController.getAll();
            isNew = false;
        }

        public StudentManagerViewModel(Student s, string title)
        {
            _student = new Student(DateTime.Today);
            _corsi = CorsiController.getAll();
            _title = title;
            isNew = false;
        }

        internal void Confirm()
        {
            StudentController.add(Student);
        }
    }
}
