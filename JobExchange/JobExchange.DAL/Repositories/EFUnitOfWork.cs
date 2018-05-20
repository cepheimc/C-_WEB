using System;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private JobExchangeContext db;
        private CategoryRepository categoryRepository;
        private CustomerRepository customerRepository;
        private ResumeRepository resumeRepository;
        private EmployeeRepository employeeRepository;
        private VacancyRepository vacancyRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new JobExchangeContext(connectionString);
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }

        public IRepository<Resume> Resumes
        {
            get
            {
                if (resumeRepository == null)
                    resumeRepository = new ResumeRepository(db);
                return resumeRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<Vacancy> Vacancies
        {
            get
            {
                if (vacancyRepository == null)
                    vacancyRepository = new VacancyRepository(db);
                return vacancyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
