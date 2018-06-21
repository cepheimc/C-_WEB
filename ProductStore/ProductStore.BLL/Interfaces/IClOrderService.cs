using System;
using System.Collections.Generic;
using System.Linq;
using ProductStore.BLL.DTO;

namespace ProductStore.BLL.Interfaces
{
    public interface IClOrderService
    {
        void AddClOrder(ClientOrderDTO clientOrderDTO);
        void UpdateClOrder(ClientOrderDTO clientOrderDTO);
        void DeleteClOrder(int? id);
        ClientOrderDTO GetClientOrder(int? id);
        IQueryable<ClientOrderDTO> GetClientOrders();
        void Dispose();
    }
}
