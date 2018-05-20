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
        public Category Categories { get; set; }

        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
