using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class ClOrderViewModel
    {
        public int ClientOrderId { get; set; }

        [Display(Name = "Имя")]
        public string ClientName { get; set; }

        [Display(Name = "Телефон")]
        public string ClientPhone { get; set; }
        public DateTime ClOrderDate { get; set; }

        [Display(Name = "Адрес")]
        public string ClOrderAddress { get; set; }
        public bool IsActive { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }
    }
}