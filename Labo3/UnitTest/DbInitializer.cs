using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace UnitTest
{
    public class DbInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            Customer customer = new Customer()
            {
                Name = "Xavier",
                AddressLine1 = "Rue du Lion",
                Country = "Arlon",
                Email = "DentaPansé@me.com",
                Id = 1,
                Remark = "Attention il ne vous reste plus bcp de temps pour vous enregistrer !",
                PostCode = "6700"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
