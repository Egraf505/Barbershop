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
    /// Логика взаимодействия для RecordDatePage.xaml
    /// </summary>
    public partial class RecordDatePage : Page
    {
        private BarbershopContext _context;

        public RecordDatePage()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (Daterecord.SelectedDate == null)
            {
                MessageBox.Show("Дата не выбрана");
            }
            else
            {
                try
                {
                    using (_context = new BarbershopContext())
                    {
                        RecordListBox.Items.Clear();

                        var records = _context.Records.Where(x => x.DateOfRecord.Date == Daterecord.SelectedDate);

                        foreach ( var record in records) 
                        {
                            RecordListBox.Items.Add(record);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
