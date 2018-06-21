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
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public void AddProduct(ProductDTO productDTO)
        {
            bool active = true;

            if(productDTO.ProductQuantity <= 0)
            {
                active = false;
            }

            Product product = new Product
            {
                ProductName = productDTO.ProductName,
                ProductQuantity = productDTO.ProductQuantity,
                ProductPrice = productDTO.ProductPrice,
                IsPresent = active
            };

            Database.Products.Create(product);
            Database.Save();
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            Product product = Database.Products.Get(productDTO.ProductId);
            if (product == null)
                throw new ValidationException("Продукт не найден", "");
            bool active = true;

            if (productDTO.ProductQuantity <= 0)
            {
                active = false;
            }            
                product.ProductName = productDTO.ProductName;
                product.ProductQuantity = productDTO.ProductQuantity;
                product.ProductPrice = productDTO.ProductPrice;
                product.IsPresent = active;

            Database.Products.Update(product);
            Database.Save();
        }

        public void DeleteProduct(int? id)
        {
            Database.Products.Delete(id.Value);
            Database.Save();
        }

        public IQueryable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            var query = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
            return query.AsQueryable();
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id товара", "");
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Товар не найден", "");

            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductQuantity = product.ProductQuantity,
                ProductPrice = product.ProductPrice,
                IsPresent = product.IsPresent
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
