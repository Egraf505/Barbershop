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

        public MainWindow()
        {
            InitializeComponent();

            _recordPage= new RecordPage();

            MainFrame.Navigate(_recordPage);
        }

        private void GoToRecord_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_recordPage);
        }
    }
}
