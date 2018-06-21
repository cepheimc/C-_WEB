using System;
using System.Linq;
using ProductStore.DAL.Entities;
using ProductStore.DAL.EF;
using ProductStore.DAL.Interfaces;
using System.Data.Entity;

namespace ProductStore.DAL.Repositories
{
    public class ClOrderRepository : IRepository<ClientOrder>
    {
        private StoreContext db;

        public ClOrderRepository(StoreContext context)
        {
            this.db = context;
        }

        public IQueryable<ClientOrder> GetAll()
        {
            return db.ClientOrders;
        }

        public ClientOrder Get(int id)
        {
            return db.ClientOrders.Find(id);
        }

        public void Create(ClientOrder clientOrder)
        {
            db.ClientOrders.Add(clientOrder);
        }

        public void Update(ClientOrder clientOrder)
        {
            db.Entry(clientOrder).State = EntityState.Modified;
        }

        public IQueryable<ClientOrder> Find(Func<ClientOrder, Boolean> predicate)
        {
            IQueryable<ClientOrder> query = (IQueryable <ClientOrder>)db.ClientOrders.Where(predicate).ToList();
            return query;
        }

        public void Delete(int id)
        {
            ClientOrder clientOrder = db.ClientOrders.Find(id);
            if (clientOrder != null)
                db.ClientOrders.Remove(clientOrder);
        }
    }
}
