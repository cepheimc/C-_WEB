using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Vacancy
    {
        public int vacancy_Id { get; set; }
        public string vacancy_name { get; set; }
        public DateTime date { get; set; }
        public string vacancy_descript { get; set; }

        public int category_Id { get; set; }
        public Category category { get; set; }

        public int customer_Id { get; set; }
        public Customer customer { get; set; }
    }
}
