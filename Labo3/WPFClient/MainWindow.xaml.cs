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
            _customer = _context.Customers.First<Customer>();

            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Formulaire.DataContext = _customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.Customers.First().AccountBalance += (double)MontantAAjouterAuCompte.Value;
            
            _context.SaveChanges();
        }
    }
}
