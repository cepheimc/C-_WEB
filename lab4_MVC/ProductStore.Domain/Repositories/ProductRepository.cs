using System.Collections.Generic;
using ProductStore.Domain.Entities;
using ProductStore.Domain.Interfaces;
using ProductStore.Domain.EF;

namespace ProductStore.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductStoreContext db = new ProductStoreContext();

        public ProductRepository(ProductStoreContext context)
        {
            db = context;
        }

        public IEnumerable<Product> Products
        {
            get { return db.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
                db.Products.Add(product);
            else
            {
                Product dbEntry = db.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.ProductQuantity = product.ProductQuantity;
                    dbEntry.Price = product.Price;                    
                }
            }
            db.SaveChanges();
        }


        public Product DeleteProduct(int productId)
        {
            Product dbEntry = db.Products.Find(productId);
            if (dbEntry != null)
            {
                db.Products.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
