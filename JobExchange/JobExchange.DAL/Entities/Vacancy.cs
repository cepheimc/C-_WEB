using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Vacancy
    {
        public int VacancyID { get; set; }
        public string VacancyName { get; set; }
        public DateTime Date { get; set; }
        public string VacancyDescript { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Company { get; set; }

        public Customer Customer { get; set; }
    }
}