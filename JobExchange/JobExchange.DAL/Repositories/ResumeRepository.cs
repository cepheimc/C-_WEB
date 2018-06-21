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

        public IQueryable<Resume> GetAll()
        {
            return db.Resumes;
        }

        public IQueryable<Resume> OrderByName()
        {
            return db.Resumes.OrderBy(r => r.ResumeName);
        }

        public IQueryable<Resume> OrderByDecName()
        {
            return db.Resumes.OrderByDescending(r => r.ResumeName);
        }

        public IQueryable<Resume> Where(string term)
        {
            return db.Resumes.Where(r => r.ResumeName.Contains(term) 
            || r.ResumeDescript.Contains(term) || r.CategoryName.Contains(term)).AsQueryable();
        }

        public Resume Get(int id)
        {
            return db.Resumes.Find(id);
        }

        public Resume Get(string search)
        {
            return db.Resumes.Find(search);
        }

        public void Create(Resume resume)
        {
            db.Resumes.Add(resume);
        }

        public void Update(Resume resume)
        {
            db.Entry(resume).State = EntityState.Modified;
        }

        public IQueryable<Resume> Find(Func<Resume, Boolean> predicate)
        {
            return db.Resumes.Where(predicate).AsQueryable();
        }

        public void Delete(int id)
        {
            Resume resume = db.Resumes.Find(id);
            if (resume != null)
                db.Resumes.Remove(resume);
        }
    }
}
