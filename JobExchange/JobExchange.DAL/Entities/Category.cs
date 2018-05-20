using System;
using System.Collections.Generic;

namespace JobExchange.DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
