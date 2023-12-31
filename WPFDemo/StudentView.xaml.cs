﻿using System;
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
    /// Logica di interazione per StudentView.xaml
    /// </summary>
    public partial class StudentView : Page
    {
        private StudentViewModel vm;

        public StudentView()
        {
            InitializeComponent();
            vm = new StudentViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Filter();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            

            vm.deleteStudent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.newStudent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new StudentManagerView());
            vm.updateStudent();
        }
    }
}
