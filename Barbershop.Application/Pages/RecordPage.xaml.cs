using Barbershop.Persistence;
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

namespace Barbershop.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary> 

    public partial class RecordPage : Page
    {
        private BarbershopContext _context;
        public RecordPage()
        {
            InitializeComponent();

            SetService();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetService();
        }

        private void SetService()
        {
            try
            {
                using (_context = new BarbershopContext())
                {
                    ServicesComboBox.ItemsSource = _context.Services.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
