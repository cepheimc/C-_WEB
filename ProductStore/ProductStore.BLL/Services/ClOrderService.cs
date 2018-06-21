using System;
using System.Collections.Generic;
using System.Linq;
using ProductStore.BLL.DTO;
using ProductStore.BLL.Interfaces;
using ProductStore.BLL.Infrastructure;
using ProductStore.DAL.Entities;
using ProductStore.DAL.Interfaces;
using AutoMapper;

namespace ProductStore.BLL.Services
{
    public class ClOrderService : IClOrderService
    {
        IUnitOfWork Database { get; set; }

        public ClOrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddClOrder(ClientOrderDTO clientOrderDTO)
        {
            Product product = Database.Products.Get(clientOrderDTO.ProductId);

            if (product == null)
                throw new ValidationException("Товар не найден", "");

            ClientOrder order = new ClientOrder
            {
                ClOrderDate = DateTime.Now,
                ClientName = clientOrderDTO.ClientName,
                ClientPhone = clientOrderDTO.ClientPhone,
                ClOrderAddress = clientOrderDTO.ClOrderAddress,
                ProductId = product.ProductId,
                Quantity = clientOrderDTO.Quantity,
                IsActive = true
            };
            Database.ClientOrders.Create(order);
            Database.Save();
        }

        public void UpdateClOrder(ClientOrderDTO clientOrderDTO)
        {
            ClientOrder clientOrder = Database.ClientOrders.Get(clientOrderDTO.ClientOrderId);
            if (clientOrder == null)
                throw new ValidationException("Заказ магазина не найден", "");

            clientOrder.ClOrderDate = DateTime.Now;
            clientOrder.ClientName = clientOrderDTO.ClientName;
            clientOrder.ClientPhone = clientOrderDTO.ClientPhone;
            clientOrder.ClOrderAddress = clientOrderDTO.ClOrderAddress;
            clientOrder.ProductId = clientOrderDTO.ProductId;
            clientOrder.Quantity = clientOrderDTO.Quantity;
            clientOrder.IsActive = true;

            Database.ClientOrders.Update(clientOrder);
            Database.Save();
        }

        public void DeleteClOrder(int? id)
        {
            Database.ClientOrders.Delete(id.Value);
            Database.Save();
        }

        public IQueryable<ClientOrderDTO> GetClientOrders()
        {
            // IQueryable < ClientOrder > query = Database.ClientOrders.GetAll();
            // List<ClientOrderDTO> query1 = query.ToList();
            //IQueryable<ClientOrderDTO> clientOrderDTOs;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrder, ClientOrderDTO>()).CreateMapper();
            var query1 = mapper.Map<IEnumerable<ClientOrder>, List<ClientOrderDTO>>(Database.ClientOrders.GetAll());
            IQueryable<ClientOrderDTO> query = query1.AsQueryable();
            return query;
        }

        public ClientOrderDTO GetClientOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id заказа", "");
            var clientOrder = Database.ClientOrders.Get(id.Value);
            if (clientOrder == null)
                throw new ValidationException("Заказ не найден", "");

            return new ClientOrderDTO
            {
                ClOrderDate = DateTime.Now,
                ClientName = clientOrder.ClientName,
                ClientPhone = clientOrder.ClientPhone,
                ClOrderAddress = clientOrder.ClOrderAddress,
                ProductId = clientOrder.ProductId,
                Quantity = clientOrder.Quantity,
                IsActive = clientOrder.IsActive
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
