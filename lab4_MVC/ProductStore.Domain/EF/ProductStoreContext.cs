using System.Data.Entity;
using ProductStore.Domain.Entities;

namespace ProductStore.Domain.EF
{
    public class ProductStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductStoreContext() : base("ProductStore")
        {
        }
    }
}
