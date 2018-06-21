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

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public Employee Employee { get; set; }

    }
}
