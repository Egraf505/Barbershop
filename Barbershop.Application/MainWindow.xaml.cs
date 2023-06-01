using Barbershop.App.Pages;
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

namespace Barbershop.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecordPage _recordPage;
        private ServicesPage _servicesPage;
        private RecordDatePage _recordDatePage;

        public MainWindow()
        {
            InitializeComponent();

            _recordPage= new RecordPage();
            _servicesPage = new ServicesPage();
            _recordDatePage = new RecordDatePage();

            GlobalFrame.Frame = MainFrame;

            MainFrame.Navigate(_recordPage);
        }

        private void GoToRecord_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_recordPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_servicesPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_recordDatePage);
        }
    }
}
