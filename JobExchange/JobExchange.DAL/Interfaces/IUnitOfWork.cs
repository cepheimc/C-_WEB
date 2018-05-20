using System;
using JobExchange.DAL.Entities;

namespace JobExchange.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Resume> Resumes { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Vacancy> Vacancies { get; }
        void Save();
    }
}
