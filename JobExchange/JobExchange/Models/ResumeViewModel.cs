using System;
using System.Collections.Generic;
using JobExchange.BLL.DTO;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JobExchange.Models
{
    public class ResumeViewModel 
    {
        public int ResumeId { get; set; }

        [Display(Name = "Название")]
        public string ResumeName { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Описание")]
        public string ResumeDescript { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name = "Имя")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string EmployeelastName { get; set; }
        

        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

    }
}