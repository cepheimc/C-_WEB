using System;
using System.Linq;

namespace ProductStore.DAL.Entities
{
    public class ClientOrder
    {
        public int ClientOrderId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public DateTime ClOrderDate { get; set; }
        public string ClOrderAddress { get; set; }
        public bool IsActive { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

    }
}
