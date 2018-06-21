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
    public class ShopOrderController : Controller
    {
        IShOrderService shOrderService;
        public ShopOrderController(IShOrderService serv)
        {
            shOrderService = serv;
        }

        public ActionResult Index()
        {
            IQueryable<ShopOrderDTO> shOrderDTOs = shOrderService.GetShopOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopOrderDTO, ProductViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<ShopOrderDTO>, List<ShOrderViewModel>>(shOrderDTOs);
            return View(orders.AsQueryable());
        }

        public ActionResult Details(int id)
        {
            ShopOrderDTO shopOrder = shOrderService.GetShopOrder(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopOrderDTO, ShOrderViewModel>()).CreateMapper();
            var customView = mapper.Map<ShOrderViewModel>(shopOrder);
            return View(customView);
        }

        public ActionResult Create()
        {
            var newShopOrder = new ShOrderViewModel();
            return View(newShopOrder);
        }

        [HttpPost]
        public ActionResult Create(ShOrderViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var shOrder = new ShopOrderDTO
                {
                    ProductQuantity = viewModel.ProductQuantity,
                    ShopAddress = viewModel.ShopAddress,
                    ShExpDate = viewModel.ShExpDate,
                    ProductId = viewModel.ProductId
                };

                shOrderService.AddShOrder(shOrder);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            ShopOrderDTO shOrder = shOrderService.GetShopOrder(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopOrderDTO,ShOrderViewModel>()).CreateMapper();
            var productView = mapper.Map<ShOrderViewModel>(shOrder);

            return View(productView);
        }

        [HttpPost]
        public ActionResult Edit(int id, ShOrderViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShOrderViewModel, ShopOrderDTO>()).CreateMapper();
                var productView = mapper.Map(viewModel, shOrderService.GetShopOrder(id));

                shOrderService.UpdateShOrder(productView);


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
            ShopOrderDTO shOrder = shOrderService.GetShopOrder(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopOrderDTO, ShOrderViewModel>()).CreateMapper();
            var productView = mapper.Map<ShopOrderDTO, ShOrderViewModel>(shOrder);
            return View(productView);
        }

        [HttpPost]
        public ActionResult Delete(int id, ShOrderViewModel viewModel)
        {
            try
            {
                shOrderService.DeleteShOrder(id);
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
            shOrderService.Dispose();
            base.Dispose(disposing);
        }
    }
}