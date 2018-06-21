using System.Linq;
using System.ComponentModel.DataAnnotations;
using JobExchange.BLL.DTO;

namespace JobExchange.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Display(Name = "Имя")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Компания")]
        public string CompanyName { get; set; }

        [Display(Name = "Адрес")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Должность")]
        public string CustomerDescript { get; set; }

    }
}