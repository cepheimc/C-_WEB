using System;
using ProductStore.DAL.Entities;

namespace ProductStore.BLL.DTO
{
    public class ShopOrderDTO
    {
        public int ShopOrderId { get; set; }
        public DateTime ShOrderDate { get; set; }
        public string ShopAddress { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime ShExpDate { get; set; }

        public int ProductId { get; set; }
    }
}
