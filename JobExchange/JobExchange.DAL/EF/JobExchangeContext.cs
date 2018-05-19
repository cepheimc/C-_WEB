using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using JobExchange.DAL.Entities;

namespace JobExchange.DAL.EF
{
    public class JobExchangeContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Unemployed> Unemployeds { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        static JobExchangeContext()
        {
            Database.SetInitializer<JobExchangeContext>(new DropCreateDatabaseIfModelChanges<JobExchangeContext>());
        }

        public JobExchangeContext(string connectionS) : base(connectionS)
        {

        }

    }

    public class ExchangeDbInitializer : DropCreateDatabaseIfModelChanges<JobExchangeContext>
    {
        protected override void Seed(JobExchangeContext db)
        {
            db.Categories.Add(new Category { category_Id = 1, category_name = "IT" });
            db.Categories.Add(new Category { category_Id = 2, category_name = "Art" });
            db.Categories.Add(new Category { category_Id = 1, category_child_Id = 1, category_name = "Software" });
            db.Categories.Add(new Category { category_Id = 1, category_child_Id = 2, category_name = "Web" });
            db.Categories.Add(new Category { category_Id = 2, category_child_Id = 3, category_name = "Music" });
            db.Categories.Add(new Category { category_Id = 2, category_child_Id = 4, category_name = "Picture" });

            db.Unemployeds.Add(new Unemployed { unempl_Id = 1, unem_first_name = "Carson", unem_last_name = "Alexander", address = "USA" });
            db.Unemployeds.Add(new Unemployed { unempl_Id = 2, unem_first_name = "Meredith", unem_last_name = "Alonso", address = "USA" });
            db.Unemployeds.Add(new Unemployed { unempl_Id = 3, unem_first_name = "Yan", unem_last_name = "Li", address = "Japan" });
            db.Unemployeds.Add(new Unemployed { unempl_Id = 4, unem_first_name = "Nino", unem_last_name = "Olivetto", address = "GB" });

            db.Customers.Add(new Customer { customer_Id = 1, cus_first_name = "Arturo", cus_last_name = "Anand", company = "Kodisoft", company_address = "Canada" });
            db.Customers.Add(new Customer { customer_Id = 2, cus_first_name = "Gytis", cus_last_name = "Barzdukas", company = "Google", company_address = "USA" });
            db.Customers.Add(new Customer { customer_Id = 3, cus_first_name = "Peggy", cus_last_name = "Justice", company = "Netsoft", company_address = "Brazilian" });

            db.Vacancies.Add(new Vacancy { vacancy_Id = 1, vacancy_name = "Vacancy1.doc", category_Id = 1, customer_Id = 1, date = DateTime.Parse("2005-09-01") });
            db.Vacancies.Add(new Vacancy { vacancy_Id = 2, vacancy_name = "Vacancy2.doc", category_Id = 2, customer_Id = 2, date = DateTime.Parse("2001-09-01") });
            db.Vacancies.Add(new Vacancy { vacancy_Id = 3, vacancy_name = "Vacancy3.doc", category_Id = 3, customer_Id = 3, date = DateTime.Parse("2002-09-01") });
            db.Vacancies.Add(new Vacancy { vacancy_Id = 4, vacancy_name = "Vacancy4.doc", category_Id = 4, customer_Id = 4, date = DateTime.Parse("2005-09-01") });

            db.Resumes.Add(new Resume { resume_Id = 1, resume_name = "Full stack developer", category_Id = 1, unemp_Id = 1, date = DateTime.Parse("2004-10-02") });
            db.Resumes.Add(new Resume { resume_Id = 1, resume_name = "Junior", category_Id = 2, unemp_Id = 2, date = DateTime.Parse("2003-04-27") });
            db.Resumes.Add(new Resume { resume_Id = 1, resume_name = "Teacher", category_Id = 3, unemp_Id = 3, date = DateTime.Parse("2002-08-20") });

            db.SaveChanges();
        }
    }
}
