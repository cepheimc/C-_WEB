using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStore.Domain.Repositories;
using ProductStore.Domain.Entities;
using ProductStore.Domain.EF;
using lab4_MVC.Models;

namespace lab4_MVC.Controllers
{
    public class ProductController : Controller
    {
        private static ProductStoreContext db = new ProductStoreContext();
        private ProductRepository productRepository = new ProductRepository(db);
      /*  public ProductController(IProductRepository repo)
        {
            productRepository = repo;
        }*/
        // GET: Product
        public ActionResult Index()
        {
            return View(productRepository.Products);
        }

        public ActionResult Edit(int productId)
        {
            Product product = productRepository.Products
                .FirstOrDefault(g => g.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {                
                productRepository.SaveProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product product = productRepository.DeleteProduct(productId);
            if (product != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    product.ProductName);
            }
            return RedirectToAction("Index");
        }
    }
}