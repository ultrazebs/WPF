using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logica di interazione per Calculator.xaml
    /// </summary>
    public partial class Calculator : Window, INotifyPropertyChanged
    {
        CalcolatriceVIewModel VM;
        public Calculator()
        {
            InitializeComponent();
            VM = new CalcolatriceVIewModel();
            DataContext = VM;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VM.tasto("5");
        }
    }
}
