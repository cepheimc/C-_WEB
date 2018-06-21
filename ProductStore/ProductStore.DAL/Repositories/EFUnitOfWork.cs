using System;
using ProductStore.DAL.Entities;
using ProductStore.DAL.EF;
using ProductStore.DAL.Interfaces;


namespace ProductStore.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StoreContext db;
        private ProductRepository productRepository;
        private ClOrderRepository clOrderRepository;
        private ShOrderRepository shOrderRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new StoreContext(connectionString);
        }        

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<ClientOrder> ClientOrders
        {
            get
            {
                if (clOrderRepository == null)
                    clOrderRepository = new ClOrderRepository(db);
                return clOrderRepository;
            }
        }

        public IRepository<ShopOrder> ShopOrders
        {
            get
            {
                if (shOrderRepository == null)
                    shOrderRepository = new ShOrderRepository(db);
                return shOrderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
