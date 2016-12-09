using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        private CompanyContext _context;
        private Customer _customer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _context = new CompanyContext();
            _customer = _context.Customers.First<Customer>();
            Formulaire.DataContext = _customer;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                _customer.AccountBalance += (double)MontantAAjouterAuCompte.Value;

                var customerToUpdate = await _context.Customers.FindAsync(1);
                if(customerToUpdate == null)
                {
                    //Client supprimer c'est balot
                    System.Console.WriteLine("Client supprimé");
                }
                else
                {
                    try
                    {
                        //_context.Entry(customerToUpdate).OriginalValues["RowVersion"] = _customer.RowVersion;
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        System.Console.WriteLine(   "The record you attempted to edit "
                                                    + "was modified by another user after you got the original value. The "
                                                    + "edit operation was canceled and the current values in the database "
                                                    + "have been displayed. If you still want to edit this record, click "
                                                    + "the Save button again. Otherwise click the Back to List hyperlink.\n" + ex.Message);
                    }
                }


            }
            catch(Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
    }
}
