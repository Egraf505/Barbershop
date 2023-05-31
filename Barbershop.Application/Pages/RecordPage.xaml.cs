using Barbershop.Domain;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (PhoneNumberBox.Text.Contains('_'))
            {
                errors.Append("\nНомер не должен быть пустым");
            }

            if (string.IsNullOrEmpty(NameBox.Text))
            {
                errors.Append("\nИмя не должно быть пустым");
            }

            if (string.IsNullOrEmpty(SurNameBox.Text))
            {
                errors.Append("\nФамилия не должна быть пустым");
            }

            if (string.IsNullOrEmpty(MiddleNameBox.Text))
            {
                errors.Append("\nОтчество не должна быть пустым");
            }

            if (ServicesComboBox.SelectedItem == null)
            {
                errors.Append("\nУслуга не выбрана");
            }

            if (Date.SelectedDate != null)
            {
                if (Date.SelectedDate < DateTime.Now)
                {
                    errors.Append($"\nНельзя записать на {Date.SelectedDate.Value.ToShortDateString()}");
                }
            }
            else
            {
                errors.Append("\nДата не выбрана");
            }

            if (TimeComboBox.SelectedItem == null)
            {
                errors.Append("\nВремя не выбрано");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                try
                {
                    var time = TimeSpan.Parse((string)TimeComboBox.SelectedItem);

                    var datetime = Date.SelectedDate.Value.Date.Add(time);

                    using (_context = new BarbershopContext())
                    {
                        var newRecord = new Record()
                        {
                            PhoneNumber = PhoneNumberBox.Text,
                            Name = NameBox.Text,
                            LastName = SurNameBox.Text,
                            MiddleName = MiddleNameBox.Text,
                            DateOfRecord = datetime
                        };

                        var service = _context.Attach((Service)ServicesComboBox.SelectedItem);

                        newRecord.Services.Add(service.Entity);

                        if (_context.Records.Any(x => x.DateOfRecord == newRecord.DateOfRecord))
                        {
                            MessageBox.Show("На это время уже есть запись");
                            return;
                        }
                        else
                        {
                            _context.Records.Add(newRecord);
                            _context.SaveChanges();

                            MessageBox.Show("Запись успешно добавлена");
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
