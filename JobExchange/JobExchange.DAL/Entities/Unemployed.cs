using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Unemployed
    {
        public int unempl_Id { get; set; }
        public string unem_first_name { get; set; }
        public string unem_last_name { get; set; }
        public string address { get; set; }

        public ICollection<Resume> resumes { get; set; }
    }
}
