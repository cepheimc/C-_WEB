using System;
using JobExchange.DAL.Entities;

namespace JobExchange.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IPeopleRepository<Customer> Customers { get; }
        IRepository<Resume> Resumes { get; }
        IPeopleRepository<Employee> Employees { get; }
        IRepository<Vacancy> Vacancies { get; }
        void Save();
    }
}
