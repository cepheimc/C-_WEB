using System;
using System.Linq;


namespace ProductStore.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
    T Get(int id);
    IQueryable<T> Find(Func<T, Boolean> predicate);
    void Create(T item);
    void Update(T item);
    void Delete(int id);
}
}
