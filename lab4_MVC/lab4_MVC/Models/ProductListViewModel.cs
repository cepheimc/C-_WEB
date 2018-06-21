using System.Collections.Generic;
using ProductStore.Domain.Entities;

namespace lab4_MVC.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}