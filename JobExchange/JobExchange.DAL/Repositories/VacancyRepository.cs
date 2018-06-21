using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class VacancyRepository : IRepository<Vacancy>
    {
        private JobExchangeContext db;

        public VacancyRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IQueryable<Vacancy> GetAll()
        {
            return db.Vacancies;
        }

        public IQueryable<Vacancy> OrderByName()
        {
            return db.Vacancies.OrderBy(v => v.VacancyName);
        }

        public IQueryable<Vacancy> OrderByDecName()
        {
            return db.Vacancies.OrderByDescending(v => v.VacancyName);
        }

        public IQueryable<Vacancy> Where(string term)
        {
            return db.Vacancies.Where(r => r.VacancyName.Contains(term) 
            || r.VacancyDescript.Contains(term) || r.CategoryName.Contains(term)).AsQueryable();
        }

        public Vacancy Get(int id)
        {
            return db.Vacancies.Find(id);
        }

        public void Create(Vacancy vacancy)
        {
            db.Vacancies.Add(vacancy);
        }

        public void Update(Vacancy vacancy)
        {
            db.Entry(vacancy).State = EntityState.Modified;
        }

        public IQueryable<Vacancy> Find(Func<Vacancy, Boolean> predicate)
        {
            return db.Vacancies.Where(predicate).AsQueryable();
        }

        public void Delete(int id)
        {
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy != null)
                db.Vacancies.Remove(vacancy);
        }
    }
}
