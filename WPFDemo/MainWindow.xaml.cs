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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDemo.viewModels;

namespace WPFDemo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel vm;



        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            DataContext = vm;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            vm.Logout();
            NavigationService.NavigationService.Navigate(new Login());
        }

        private void RandomStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new randomStudent());
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new Calculator());
        }
    }
}
