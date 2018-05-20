using System;
using JobExchange.DAL.Entities;

namespace JobExchange.BLL.DTO
{
    class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeAddress { get; set; }
        public bool Unemplyed { get; set; }



    }
}
