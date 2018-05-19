using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Customer
    {
        public int customer_Id { get; set; }
        public string cus_first_name { get; set; }
        public string cus_last_name { get; set; }
        public string company { get; set; }
        public string company_address { get; set; }
        public string cust_descript { get; set; }

        public ICollection<Vacancy> vacancies { get; set; }
    }
}
