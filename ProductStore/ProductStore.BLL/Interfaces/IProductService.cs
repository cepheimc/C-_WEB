using System;
using System.Linq;
using System.Collections.Generic;
using ProductStore.BLL.DTO;

namespace ProductStore.BLL.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDTO productDTO);
        void UpdateProduct(ProductDTO productDTO);
        void DeleteProduct(int? id);
        ProductDTO GetProduct(int? id);
        IQueryable<ProductDTO> GetProducts();
        void Dispose();
    }
}
