using System;
using System.Linq;
using System.Collections.Generic;
using ProductStore.BLL.DTO;

namespace ProductStore.BLL.Interfaces
{
    public interface IShOrderService
    {
        void AddShOrder(ShopOrderDTO shopOrderDTO);
        void UpdateShOrder(ShopOrderDTO shopOrderDTO);
        void DeleteShOrder(int? id);
        ShopOrderDTO GetShopOrder(int? id);
        IQueryable<ShopOrderDTO> GetShopOrders();
        void Dispose();
    }
}
