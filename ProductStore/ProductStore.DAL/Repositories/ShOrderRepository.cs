using System;
using System.Linq;
using ProductStore.DAL.Entities;
using ProductStore.DAL.EF;
using ProductStore.DAL.Interfaces;
using System.Data.Entity;

namespace ProductStore.DAL.Repositories
{
    public class ShOrderRepository : IRepository<ShopOrder>
    {
        private StoreContext db;

        public ShOrderRepository(StoreContext context)
        {
            this.db = context;
        }

        public IQueryable<ShopOrder> GetAll()
        {
            return db.ShopOrders;
        }

        public ShopOrder Get(int id)
        {
            return db.ShopOrders.Find(id);
        }

        public void Create(ShopOrder shopOrder)
        {
            db.ShopOrders.Add(shopOrder);
        }

        public void Update(ShopOrder shopOrder)
        {
            db.Entry(shopOrder).State = EntityState.Modified;
        }

        public IQueryable<ShopOrder> Find(Func<ShopOrder, Boolean> predicate)
        {
            IQueryable<ShopOrder> query = (IQueryable<ShopOrder>)db.ShopOrders.Where(predicate).ToList();
            return query;
        }

        public void Delete(int id)
        {
            ShopOrder shopOrder = db.ShopOrders.Find(id);
            if (shopOrder != null)
                db.ShopOrders.Remove(shopOrder);
        }
    }
}
