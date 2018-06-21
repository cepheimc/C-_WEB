using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStore.BLL.Infrastructure;
using ProductStore.BLL.Interfaces;
using ProductStore.BLL.DTO;
using ProductStore.Models;
using AutoMapper;

namespace ProductStore.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        IShOrderService shOrderService;
        IClOrderService clOrderService;
        public ProductController(IProductService product, IShOrderService shop, IClOrderService client )
        {
            productService = product;
            shOrderService = shop;
            clOrderService = client;
        }

        public ActionResult Index()
        {
            IQueryable<ProductDTO> productDTOs = productService.GetProducts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDTOs);
            IQueryable query = products.AsQueryable();
            return View(query);
        }

        public ActionResult Create()
        {
            var newPtoduct = new ProductViewModel();
            return View(newPtoduct);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                
                var product = new ProductDTO
                {
                    ProductName = viewModel.ProductName,
                    ProductQuantity = viewModel.ProductQuantity,
                    ProductPrice = viewModel.ProductPrice
                };

                productService.AddProduct(product);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);                
            }
            return View(viewModel);
        }

        public ActionResult MakeShopOrder(int? id)
        {
            try
            {
                ProductDTO product = productService.GetProduct(id);
                var order = new ShOrderViewModel { ProductId = product.ProductId };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeShopOrder(ShOrderViewModel order)
        {
            try
            {
                var orderDto = new ShopOrderDTO
                {
                    ProductId = order.ProductId,
                    ShopAddress = order.ShopAddress,
                    ProductQuantity = order.ProductQuantity,
                    ShExpDate = order.ShExpDate
                };
                shOrderService.AddShOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        public ActionResult MakeClientOrder(int? id)
        {
            try
            {
                ProductDTO product = productService.GetProduct(id);
                var order = new ClOrderViewModel { ProductId = product.ProductId };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeClientOrder(int id, ClOrderViewModel order)
        {
            try
            {
                ProductDTO product = productService.GetProduct(id);
                ClientOrderDTO orderDTO;
                if(product.ProductQuantity >= order.Quantity)
                {
                    orderDTO = new ClientOrderDTO
                    {
                        ProductId = order.ProductId,
                        ClientName = order.ClientName,
                        Quantity = order.Quantity,
                        ClientPhone = order.ClientPhone,
                        ClOrderAddress = order.ClOrderAddress,
                        ClOrderDate = DateTime.Now,
                        IsActive = false
                    };
                }
                else
                {
                    orderDTO = new ClientOrderDTO
                    {
                        ProductId = order.ProductId,
                        ClientName = order.ClientName,
                        Quantity = order.Quantity,
                        ClientPhone = order.ClientPhone,
                        ClOrderAddress = order.ClOrderAddress,
                        ClOrderDate = DateTime.Now,
                        IsActive = true
                    };
                }
                
                clOrderService.AddClOrder(orderDTO);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        public ActionResult Edit(int id)
        {
            ProductDTO product = productService.GetProduct(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, ProductDTO>()).CreateMapper();
            var productView = mapper.Map<ProductViewModel>(product);

            return View(productView);
        }

        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, ProductDTO>()).CreateMapper();
                var productView = mapper.Map(viewModel, productService.GetProduct(id));               

                productService.UpdateProduct(productView);
                

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);                
            }
            
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            ProductDTO product = productService.GetProduct(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var productView = mapper.Map<ProductDTO, ProductViewModel>(product);
            return View(productView);
        }

        [HttpPost]
        public ActionResult Delete(int id, ProductViewModel viewModel)
        {
            try
            {
                productService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "An error has occured. This Employee was not deleted.");                
            }
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}