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

        public IEnumerable<Vacancy> GetAll()
        {
            return db.Vacancies;
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

        public IEnumerable<Vacancy> Find(Func<Vacancy, Boolean> predicate)
        {
            return db.Vacancies.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy != null)
                db.Vacancies.Remove(vacancy);
        }
    }
}
