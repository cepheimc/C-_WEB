using System;
using System.Linq;
using JobExchange.BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace JobExchange.Models
{
    public class VacancyViewModel
    {
        public int VacancyId { get; set; }

        [Display(Name = "Название")]
        public string VacancyName { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Описание")]
        public string VacancyDescript { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }


        public int CustomerId { get; set; }

        [Display(Name = "Имя")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Компания")]
        public string Company { get; set; }
       
    }
}