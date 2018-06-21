using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductStore.DAL.Entities;

namespace ProductStore.DAL.EF
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }

        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreDbInitializer());
        }
        public StoreContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            db.Products.Add(new Product { ProductId = 1, ProductName = "Phone", ProductQuantity = 100, ProductPrice = 250, IsPresent = true});
            db.Products.Add(new Product { ProductId = 2, ProductName = "TV", ProductQuantity = 10, ProductPrice = 24000, IsPresent = true });
            db.Products.Add(new Product { ProductId = 3, ProductName = "Notebook", ProductQuantity = 19, ProductPrice = 3000, IsPresent = true });
            db.Products.Add(new Product { ProductId = 4, ProductName = "Playstation", ProductQuantity = 200, ProductPrice = 100, IsPresent = true });

            db.ClientOrders.Add(new ClientOrder { ClientOrderId = 1, ClOrderDate = DateTime.Parse("2004-10-02"), ProductId = 1, Quantity = 1,  ClientName = "Alina",
                ClientPhone = "09536663847", IsActive = false, ClOrderAddress = "Kiev"});
            db.ClientOrders.Add(new ClientOrder { ClientOrderId = 2, ClOrderDate = DateTime.Parse("2005-12-28"), ProductId = 2, Quantity = 1, ClientName = "Ksenia",
                ClientPhone = "0671239465", IsActive = false, ClOrderAddress = "Kiev" });
            db.ClientOrders.Add(new ClientOrder { ClientOrderId = 3, ClOrderDate = DateTime.Parse("2008-04-13"), ProductId = 3, Quantity = 3, ClientName = "Anton",
                ClientPhone = "0500047536", IsActive = false, ClOrderAddress = "Kiev" });

            db.ShopOrders.Add(new ShopOrder { ShopOrderId = 1, ShOrderDate = DateTime.Parse("2002-05-13"), ProductId = 3, ProductQuantity = 50,
                ShExpDate = DateTime.Parse("2002-05-15"), ShopAddress = "Kiev" });
            db.ShopOrders.Add(new ShopOrder { ShopOrderId = 2, ShOrderDate = DateTime.Parse("2003-08-10"), ProductId = 1, ProductQuantity = 100,
                ShExpDate = DateTime.Parse("2003-08-20"), ShopAddress = "Kiev" });
            db.ShopOrders.Add(new ShopOrder { ShopOrderId = 3, ShOrderDate = DateTime.Parse("2003-11-23"), ProductId = 2, ProductQuantity = 60,
                ShExpDate = DateTime.Parse("2003-11-30"), ShopAddress = "Kiev" });
            db.ShopOrders.Add(new ShopOrder { ShopOrderId = 4, ShOrderDate = DateTime.Parse("2004-02-21"), ProductId = 1, ProductQuantity = 200,
                ShExpDate = DateTime.Parse("2004-02-25"), ShopAddress = "Kiev" });
            db.SaveChanges();
        }
    }
}

