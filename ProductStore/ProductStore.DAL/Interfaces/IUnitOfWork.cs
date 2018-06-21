using System;
using ProductStore.DAL.Entities;

namespace ProductStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<ShopOrder> ShopOrders { get; }
        IRepository<ClientOrder> ClientOrders { get; }
        void Save();
    }
}
