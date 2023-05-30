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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barbershop.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        private AddService _addServicePage;
        public ServicesPage()
        {
            InitializeComponent();

            _addServicePage = new AddService();
        }

        private void AddedService_Click(object sender, RoutedEventArgs e)
        {
            GlobalFrame.Frame.Navigate(_addServicePage);
        }
    }
}