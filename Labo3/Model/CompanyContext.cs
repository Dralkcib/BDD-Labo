using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model
{
    public class CompanyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CompanyContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ConcurrencyDemo;")
        {
        }
    }
}
