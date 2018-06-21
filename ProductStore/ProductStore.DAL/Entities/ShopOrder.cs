using System;
using System.Collections.Generic;

namespace ProductStore.DAL.Entities
{
    public class ShopOrder
    {
        public int ShopOrderId { get; set; }
        public DateTime ShOrderDate { get; set; }
        public string ShopAddress { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime ShExpDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
