﻿using System;
using JobExchange.DAL.Entities;

namespace JobExchange.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Resume> Resumes { get; }
        IRepository<Unemployed> Unemployeds { get; }
        IRepository<Vacancy> Vacancies { get; }
        void Save();
    }
}