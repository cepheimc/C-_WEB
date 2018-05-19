using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class UnemployedRepository : IRepository<Unemployed>
    {
        private JobExchangeContext db;

        public UnemployedRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Unemployed> GetAll()
        {
            return db.Unemployeds;
        }

        public Unemployed Get(int id)
        {
            return db.Unemployeds.Find(id);
        }

        public void Create(Unemployed unemployed)
        {
            db.Unemployeds.Add(unemployed);
        }

        public void Update(Unemployed unemployed)
        {
            db.Entry(unemployed).State = EntityState.Modified;
        }

        public IEnumerable<Unemployed> Find(Func<Unemployed, Boolean> predicate)
        {
            return db.Unemployeds.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Unemployed unemployed = db.Unemployeds.Find(id);
            if (unemployed != null)
                db.Unemployeds.Remove(unemployed);
        }
    }
}
