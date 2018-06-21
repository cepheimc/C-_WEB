
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Название")]    
        public string ProductName { get; set; }

        [Display(Name = "Количество")]
        public int ProductQuantity { get; set; }

        [Display(Name = "Цена")]
        public decimal ProductPrice { get; set; }
    }
}