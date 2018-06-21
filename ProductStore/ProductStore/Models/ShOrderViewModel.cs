using System;
using System.ComponentModel.DataAnnotations;


namespace ProductStore.Models
{
    public class ShOrderViewModel
    {
        public int ShopOrderId { get; set; }

        [Display(Name = "Дата")]
        public DateTime ShOrderDate { get; set; }

        [Display(Name = "Адрес")]
        public string ShopAddress { get; set; }

        [Display(Name = "Количество")]
        public int ProductQuantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата завоза")]
        public DateTime ShExpDate { get; set; }

        public int ProductId { get; set; }
    }
}