using System;
using System.Collections.Generic;
using System.Linq;


namespace JobExchange.DAL.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CustomerDescript { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; } 
    }
}
