using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFDemo.Models;
using WPFDemo.viewModels;

namespace WPFDemo
{
    /// <summary>
    /// Logica di interazione per StudentManagerView.xaml
    /// </summary>
    public partial class StudentManagerView : Page
    {
        StudentManagerViewModel vm;

        public StudentManagerView()
        {
            InitializeComponent();
            vm = new StudentManagerViewModel();
            DataContext = vm;

        }
        
        public StudentManagerView(string title)
        {
            InitializeComponent();
            vm = new StudentManagerViewModel(title);
            DataContext = vm;

        }      
        
        public StudentManagerView(Student s, string title)
        {
            InitializeComponent();
            vm = new StudentManagerViewModel(s, title);
            DataContext = vm;

        }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            //vm.Annulla();
            
        }

        private void Crea_Click(object sender, RoutedEventArgs e)
        {
            vm.Confirm();
            

        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {
            vm.update();
            
        }
    }
}
