using System.Collections.Generic;
using JobExchange.BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace JobExchange.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Имя")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Адрес")]
        public string EmployeeAddress { get; set; }

        [Display(Name = "Актив")]
        public bool Unemplyed { get; set; }
    }
}