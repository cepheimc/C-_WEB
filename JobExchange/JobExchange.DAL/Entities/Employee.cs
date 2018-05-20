using System;
using System.Collections.Generic;


namespace JobExchange.DAL.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeAddress { get; set; }
        public bool Unemplyed { get; set; }

        public ICollection<Resume> Resumes { get; set; }
    }
}
