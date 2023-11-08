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
using WPFDemo.viewModels;

namespace WPFDemo
{
    /// <summary>
    /// Logica di interazione per randomStudent.xaml
    /// </summary>
    public partial class randomStudent : Window
    {
        private randomStudentViewModel vm;

        public randomStudent()
        {
            InitializeComponent();
            vm = new randomStudentViewModel();
            DataContext = vm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.generateRandom();
        }
    }
}
