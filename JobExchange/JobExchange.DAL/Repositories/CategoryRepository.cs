using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private JobExchangeContext db;

        public CategoryRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IQueryable<Category> GetAll()
        {
            return db.Categories;
        }

        public IQueryable<Category> OrderByName()
        {
            return db.Categories.OrderBy(c => c.CategoryName);
        }

        public IQueryable<Category> OrderByDecName()
        {
            return db.Categories.OrderByDescending(c => c.CategoryName);
        }

        public IQueryable<Category> Where(string term)
        {
            return db.Categories.Where(r => r.CategoryName.Contains(term)).AsQueryable();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public IQueryable<Category> Find(Func<Category, Boolean> predicate)
        {
            return db.Categories.Where(predicate).AsQueryable();
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }


        
    }
}
