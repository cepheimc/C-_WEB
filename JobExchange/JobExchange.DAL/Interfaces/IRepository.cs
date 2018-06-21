using System;
using System.Linq;
using System.Collections.Generic;

namespace JobExchange.DAL.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> GetAll();
        IQueryable<T> Where(string term);
        IQueryable<T> OrderByName();
        IQueryable<T> OrderByDecName();
        T Get(int id);
        IQueryable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
