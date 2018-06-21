using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class CustomerRepository : IPeopleRepository<Customer>
    {
        private JobExchangeContext db;

        public CustomerRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IQueryable<Customer> GetAll()
        {
            return db.Customers;
        }

        public IQueryable<Customer> Where(string term)
        {
            return db.Customers.Where(c => c.CustomerLastName.Contains(term) || c.CustomerFirstName.Contains(term)).AsQueryable();
        }

        public IQueryable<Customer> OrderByName()
        {
            return db.Customers.OrderBy(c => c.CustomerFirstName);
        }

        public IQueryable<Customer> OrderByDecName()
        {
            return db.Customers.OrderByDescending(c => c.CustomerFirstName);
        }

        public IQueryable<Customer> OrderBySurName()
        {
            return db.Customers.OrderBy(c => c.CustomerLastName);
        }

        public IQueryable<Customer> OrderByDecSurName()
        {
            return db.Customers.OrderByDescending(c => c.CustomerLastName);
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

        public IQueryable<Customer> Find(Func<Customer, Boolean> predicate)
        {
            return db.Customers.Include(vacancy => vacancy.Vacancies).Where(predicate).AsQueryable();
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }

    }
}
