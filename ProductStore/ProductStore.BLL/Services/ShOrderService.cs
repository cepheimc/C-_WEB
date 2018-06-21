using System;
using System.Linq;
using System.Collections.Generic;
using ProductStore.BLL.DTO;
using ProductStore.BLL.Interfaces;
using ProductStore.BLL.Infrastructure;
using ProductStore.DAL.Entities;
using ProductStore.DAL.Interfaces;
using AutoMapper;

namespace ProductStore.BLL.Services
{
    public class ShOrderService : IShOrderService
    {
        IUnitOfWork Database { get; set; }

        public ShOrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddShOrder(ShopOrderDTO shopOrderDTO)
        {
            Product product = Database.Products.Get(shopOrderDTO.ProductId);

            if (product == null)
                throw new ValidationException("Товар не найден", "");
            
            ShopOrder order = new ShopOrder
            {
                ShOrderDate = DateTime.Now,
                ShopAddress = shopOrderDTO.ShopAddress,
                ProductId = product.ProductId,
                ProductQuantity = shopOrderDTO.ProductQuantity,
                ShExpDate = shopOrderDTO.ShExpDate
            };
            Database.ShopOrders.Create(order);
            Database.Save();
        }

        public void UpdateShOrder(ShopOrderDTO shopOrderDTO)
        {
            ShopOrder shopOrder = Database.ShopOrders.Get(shopOrderDTO.ShopOrderId);
            if (shopOrder == null)
                throw new ValidationException("Заказ магазина не найден", "");

           // shopOrder.ProductId = shopOrderDTO.ProductId;
            shopOrder.ProductQuantity = shopOrderDTO.ProductQuantity;
            shopOrder.ShopAddress = shopOrderDTO.ShopAddress;
            shopOrder.ShExpDate = shopOrderDTO.ShExpDate;

            Database.ShopOrders.Update(shopOrder);
            Database.Save();
        }

        public void DeleteShOrder(int? id)
        {
            Database.ShopOrders.Delete(id.Value);
            Database.Save();
        }

        public IQueryable<ShopOrderDTO> GetShopOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopOrder, ShopOrderDTO>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<ShopOrder>, List<ShopOrderDTO>>(Database.ShopOrders.GetAll());
            return orders.AsQueryable();
        }

        public ShopOrderDTO GetShopOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id заказа", "");
            var shopOrder = Database.ShopOrders.Get(id.Value);
            if (shopOrder == null)
                throw new ValidationException("Заказ магазина не найден", "");

            return new ShopOrderDTO
            {
                ShOrderDate = shopOrder.ShOrderDate,
                ShopAddress = shopOrder.ShopAddress,
                ProductId = shopOrder.ProductId,
                ProductQuantity = shopOrder.ProductQuantity,
                ShExpDate = shopOrder.ShExpDate
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
