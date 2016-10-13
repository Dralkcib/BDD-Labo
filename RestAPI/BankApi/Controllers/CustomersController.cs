using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Model;

namespace BankApi.Controllers
{
    public class CustomersController : ApiController
    {
        private CompanyContext db = new CompanyContext();

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            var output = db.Customers.Include(c => c.Accounts).ToList();
            return Ok(output);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(long id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(long id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(long id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(long id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}