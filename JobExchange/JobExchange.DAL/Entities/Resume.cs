using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string ResumeName { get; set; }
        public DateTime Date { get; set; }
        public string ResumeDescript { get; set; }

        public int EmployedId { get; set; }
        public Employee Employees { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }
      
    }
}
