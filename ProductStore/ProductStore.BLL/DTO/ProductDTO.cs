using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProductStore.BLL.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsPresent { get; set; }
    }
}
