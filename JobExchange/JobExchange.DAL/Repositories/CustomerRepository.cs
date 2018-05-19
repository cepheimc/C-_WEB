using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private JobExchangeContext db;

        public CustomerRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }

        public IEnumerable<Customer> Find(Func<Customer, Boolean> predicate)
        {
            return db.Customers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }
    }
}
