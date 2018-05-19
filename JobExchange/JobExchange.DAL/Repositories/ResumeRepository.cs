using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobExchange.DAL.EF;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;

namespace JobExchange.DAL.Repositories
{
    public class ResumeRepository : IRepository<Resume>
    {
        private JobExchangeContext db;

        public ResumeRepository(JobExchangeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Resume> GetAll()
        {
            return db.Resumes;
        }

        public Resume Get(int id)
        {
            return db.Resumes.Find(id);
        }

        public void Create(Resume resume)
        {
            db.Resumes.Add(resume);
        }

        public void Update(Resume resume)
        {
            db.Entry(resume).State = EntityState.Modified;
        }

        public IEnumerable<Resume> Find(Func<Resume, Boolean> predicate)
        {
            return db.Resumes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Resume resume = db.Resumes.Find(id);
            if (resume != null)
                db.Resumes.Remove(resume);
        }
    }
}
