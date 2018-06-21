using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class EmployeeRepository : IPeopleRepository<Employee>
    {
        private JobExchangeContext db;

        public EmployeeRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IQueryable<Employee> GetAll()
        {
            return db.Employees;
        }

        public IQueryable<Employee> Where(string term)
        {
            return db.Employees.Where(e => e.EmployeeLastName.Contains(term) || e.EmployeeFirstName.Contains(term)).AsQueryable();
        }

        public IQueryable<Employee> OrderByName()
        {
            return db.Employees.OrderBy(e => e.EmployeeFirstName);
        }

        public IQueryable<Employee> OrderByDecName()
        {
            return db.Employees.OrderByDescending(e => e.EmployeeFirstName);
        }

        public IQueryable<Employee> OrderBySurName()
        {
            return db.Employees.OrderBy(e => e.EmployeeLastName);
        }

        public IQueryable<Employee> OrderByDecSurName()
        {
            return db.Employees.OrderByDescending(e => e.EmployeeLastName);
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public IQueryable<Employee> Find(Func<Employee, Boolean> predicate)
        {
            return db.Employees.Include(resume => resume.Resumes).Where(predicate).AsQueryable();
        }

        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
                db.Employees.Remove(employee);
        }

    }
}
