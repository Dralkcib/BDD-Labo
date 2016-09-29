using Model;
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

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyContext _context = new CompanyContext();
        private Customer _customer;
        private int _value = 0;
        public MainWindow()
        {
            _customer = new Customer()
            {
                AccountBalance = 10,
                Name = "Xavier",
                AddressLine1 = "Rue du Lion",
                Country = "Arlon",
                Email = "DentaPansé@me.com",
                id = 1,
                Remark = "Attention il ne vous reste plus bcp de temps pour vous enregistrer !",
                PostCode = "6700"
            };

            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Formulaire.DataContext = _customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button.DataContextProperty = _value;
            _customer.AccountBalance += 10000;
            Formulaire.DataContext = _customer;
        }
    }
}
