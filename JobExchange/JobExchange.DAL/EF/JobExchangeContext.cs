using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using JobExchange.DAL.Entities;

namespace JobExchange.DAL.EF
{
    public class JobExchangeContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        static JobExchangeContext()
        {
            Database.SetInitializer<JobExchangeContext>(new StoreDbInitializer());
        }

        public JobExchangeContext(string connectionS) : base(connectionS)
        {
            
        }

        
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<JobExchangeContext>
        {
            protected override void Seed(JobExchangeContext db)
            {
                db.Categories.Add(new Category { CategoryId = 1, CategoryName = "IT" });
                db.Categories.Add(new Category { CategoryId = 2, CategoryName = "Art" });
                db.Categories.Add(new Category { CategoryId = 3, CategoryName = "Software" });
                db.Categories.Add(new Category { CategoryId = 4, CategoryName = "Web" });

                db.Employees.Add(new Employee { EmployeeId = 1, EmployeeFirstName = "Carson", EmployeeLastName = "Alexander", EmployeeAddress = "USA", Unemplyed = true });
                db.Employees.Add(new Employee { EmployeeId = 2, EmployeeFirstName = "Meredith", EmployeeLastName = "Alonso", EmployeeAddress = "USA", Unemplyed = true });
                db.Employees.Add(new Employee { EmployeeId = 3, EmployeeFirstName = "Yan", EmployeeLastName = "Li", EmployeeAddress = "Japan", Unemplyed = true });
                db.Employees.Add(new Employee { EmployeeId = 4, EmployeeFirstName = "Nino", EmployeeLastName = "Olivetto", EmployeeAddress = "GB", Unemplyed = true });

                db.Customers.Add(new Customer { CustomerId = 1, CustomerFirstName = "Arturo", CustomerLastName = "Anand", CustomerDescript = "HR", CompanyName = "Kodisoft", CompanyAddress = "Canada" });
                db.Customers.Add(new Customer { CustomerId = 2, CustomerFirstName = "Gytis", CustomerLastName = "Barzdukas", CustomerDescript = "HR", CompanyName = "Google", CompanyAddress = "USA" });
                db.Customers.Add(new Customer { CustomerId = 3, CustomerFirstName = "Peggy", CustomerLastName = "Justice", CustomerDescript = "HR", CompanyName = "Netsoft", CompanyAddress = "Brazilian" });

                db.Vacancies.Add(new Vacancy { VacancyID = 1, VacancyName = "Full stack developer", CategoryId = 1, CustomerId = 1, Date = DateTime.Parse("2005-09-01") });
                db.Vacancies.Add(new Vacancy { VacancyID = 2, VacancyName = "Junior", CategoryId = 2, CustomerId = 2, Date = DateTime.Parse("2001-09-01") });
                db.Vacancies.Add(new Vacancy { VacancyID = 3, VacancyName = "Teacher", CategoryId = 3, CustomerId = 3, Date = DateTime.Parse("2002-09-01") });

                db.Resumes.Add(new Resume { ResumeId = 1, ResumeName = "Resume1.doc", ResumeDescript = "Interesting job", CategoryId = 1, EmployeeId = 2, Date = DateTime.Parse("2004-10-02") });
                db.Resumes.Add(new Resume { ResumeId = 2, ResumeName = "Resume2.pdf", ResumeDescript = "Interesting job", CategoryId = 2, EmployeeId = 2, Date = DateTime.Parse("2003-04-27") });
                db.Resumes.Add(new Resume { ResumeId = 3, ResumeName = "Resume3.pdf", ResumeDescript = "Interesting job", CategoryId = 3, EmployeeId = 2, Date = DateTime.Parse("2002-08-20") });
                db.Resumes.Add(new Resume { ResumeId = 4, ResumeName = "Resume4.doc", ResumeDescript = "Interesting job", CategoryId = 4, EmployeeId = 2, Date = DateTime.Parse("2006-08-23") });

                db.SaveChanges();
            }
        }
    }

    
}
