﻿using System;
using System.Collections.Generic;
using ProductStore.Domain.Entities;

namespace ProductStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
