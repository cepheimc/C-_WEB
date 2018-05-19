using System;
using System.Collections.Generic;

namespace JobExchange.DAL.Entities
{
    public class Category
    {
        public int category_Id { get; set; }
        public string category_name { get; set; }
        public int category_child_Id { get; set; }

        public ICollection<Category> category_childs { get; set; }
        public ICollection<Resume> resumes { get; set; }
        public ICollection<Vacancy> vacancies { get; set; }
    }
}
