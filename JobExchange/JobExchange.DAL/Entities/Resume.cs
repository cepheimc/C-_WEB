using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Resume
    {
        public int resume_Id { get; set; }
        public string resume_name { get; set; }
        public DateTime date { get; set; }
        public string r_descript { get; set; }

        public int unemp_Id { get; set; }
        public Unemployed unemployed { get; set; }

        public int category_Id { get; set; }
        public Category category { get; set; }
      
    }
}
