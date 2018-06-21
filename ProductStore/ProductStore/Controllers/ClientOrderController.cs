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
    public class ClientOrderController : Controller
    {
        IClOrderService clOrderService;
        public ClientOrderController(IClOrderService serv)
        {
            clOrderService = serv;
        }

        public ActionResult Index()
        {
            IQueryable<ClientOrderDTO> clientOrderDTOs = clOrderService.GetClientOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrderDTO, ClOrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<ClientOrderDTO>, List<ClOrderViewModel>>(clientOrderDTOs);
            IQueryable query = orders.AsQueryable();
            return View(query);
        }

        public ActionResult Details(int id)
        {
            ClientOrderDTO clientOrder = clOrderService.GetClientOrder(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrderDTO, ClOrderViewModel>()).CreateMapper();
            var customView = mapper.Map<ClOrderViewModel>(clientOrder);
            return View(customView);
        }

        public ActionResult Create()
        {
            var newShopOrder = new ShOrderViewModel();
            return View(newShopOrder);
        }

        [HttpPost]
        public ActionResult Create(ClOrderViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var clOrder = new ClientOrderDTO
                {
                    Quantity = viewModel.Quantity,
                    ClientName = viewModel.ClientName,
                    ClientPhone = viewModel.ClientPhone,
                    ProductId = viewModel.ProductId,
                    ClOrderAddress = viewModel.ClOrderAddress                     
                };

                clOrderService.AddClOrder(clOrder);

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
            ClientOrderDTO clOrder = clOrderService.GetClientOrder(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrderDTO, ClOrderViewModel>()).CreateMapper();
            var productView = mapper.Map<ClOrderViewModel>(clOrder);

            return View(productView);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClOrderViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClOrderViewModel, ClientOrderDTO>()).CreateMapper();
                var productView = mapper.Map(viewModel, clOrderService.GetClientOrder(id));

                clOrderService.UpdateClOrder(productView);


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
            ClientOrderDTO clOrder = clOrderService.GetClientOrder(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrderDTO, ClOrderViewModel>()).CreateMapper();
            var productView = mapper.Map<ClientOrderDTO, ClOrderViewModel>(clOrder);
            return View(productView);
        }

        [HttpPost]
        public ActionResult Delete(int id, ClOrderViewModel viewModel)
        {
            try
            {
                clOrderService.DeleteClOrder(id);
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
            clOrderService.Dispose();
            base.Dispose(disposing);
        }
    }
}