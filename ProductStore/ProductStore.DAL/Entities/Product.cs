using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStore.DAL.Entities
{
    public class Product
    { 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsPresent { get; set; }

        public ICollection<ShopOrder> ShopOrders { get; set; }
    }
}
