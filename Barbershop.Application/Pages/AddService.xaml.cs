using Barbershop.Domain;
using Barbershop.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Page
    {
        private BarbershopContext _context;

        public AddService()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void SaveServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (TitleBox.Text == string.Empty || TitleBox.Text == null)
            {
                errors.Append("\nНазвание не должно быть пустым");
            }

            if (PriceBox.Text == string.Empty || PriceBox.Text == null)
            {
                errors.Append("\nЦена не может быть пустой");
            }

            if (DescriptionBox.Text == string.Empty || DescriptionBox.Text == null)
            {
                errors.Append("\nОписание не может быть пустым");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                try
                {
                    using (_context = new BarbershopContext())
                    {
                        var newService = new Service() { Price = int.Parse(PriceBox.Text), Title = TitleBox.Text, Description = DescriptionBox.Text };

                        if (_context.Services.Any(x => x.Title == newService.Title && x.Price == newService.Price && x.Description == newService.Description))
                        {
                            MessageBox.Show("Такая услуга уже есть");
                            return;
                        }

                        _context.Services.Add(newService);
                        _context.SaveChanges();

                        MessageBox.Show("Услуга успешно добавлена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PriceBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalFrame.Frame.CanGoBack)
            {
                GlobalFrame.Frame.GoBack();
            }
        }
    }
}
