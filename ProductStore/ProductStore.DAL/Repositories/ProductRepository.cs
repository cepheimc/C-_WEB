using System;
using System.Linq;
using ProductStore.DAL.Entities;
using ProductStore.DAL.EF;
using ProductStore.DAL.Interfaces;
using System.Data.Entity;

namespace ProductStore.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext db;

        public ProductRepository(StoreContext context)
        {
            this.db = context;
        }

        public IQueryable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public IQueryable<Product> Find(Func<Product, Boolean> predicate)
        {
            IQueryable<Product> query = (IQueryable<Product>)db.Products.Where(predicate).ToList();
            return query;
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }
}
