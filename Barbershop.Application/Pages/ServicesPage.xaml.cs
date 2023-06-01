using Barbershop.Domain;
using Barbershop.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class ServicesPage : Page, INotifyPropertyChanged
    {
        private AddService _addServicePage;

        private Service _selectedService;

        private BarbershopContext _context;

        public ObservableCollection<Service> Services { get; set; }
        public Service SelectedService
        {
            get { return _selectedService; }
            set
            {
                _selectedService = value;
                OnPropertyChanged("SelectedService");
            }
        }

        public ServicesPage()
        {
            InitializeComponent();

            _addServicePage = new AddService();

            Services = new ObservableCollection<Service>();

            SetService();

            DataContext = this;
        }

        private void AddedService_Click(object sender, RoutedEventArgs e)
        {
            GlobalFrame.Frame.Navigate(_addServicePage);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void SetService()
        {
            using (_context = new BarbershopContext())
            {
                Services.Clear();
                foreach (var service in _context.Services.ToList())
                {
                    Services.Add(service);
                }
            }
        }

        private void UpdateServiceBtn(object sender, RoutedEventArgs e)
        {
            SetService();
        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesList.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить услугу?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (_context = new BarbershopContext())
                    {
                        var service = _context.Services.FirstOrDefault(x => x.Id == ((Service)ServicesList.SelectedItem).Id);

                        _context.Services.Remove(service);
                        _context.SaveChanges();

                        MessageBox.Show("Услуга удалена");
                    }

                    SetService();
                };
            }
            else
            {
                MessageBox.Show("Услуга не выбрана");
            }
        }
    }
}
