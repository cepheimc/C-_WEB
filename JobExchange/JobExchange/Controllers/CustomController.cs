using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobExchange.BLL.Interfaces;
using JobExchange.BLL.DTO;
using JobExchange.Models;
using AutoMapper;
using JobExchange.BLL.Infrastructure;

namespace JobExchange.Controllers
{
    public class CustomController : Controller
    {
        private readonly ICustomService customService;
        private readonly IVacancyService vacancyService;

        public CustomController(ICustomService custom, IVacancyService vacancy)
        {
            customService = custom;
            vacancyService = vacancy;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.SurnameSortParm = sortOrder == "LastName" ? "LastName desc" : "LastName";
            IQueryable<CustomerDTO> customerDTOs = customService.GetCustomersOrder(sortOrder);
            if (!String.IsNullOrEmpty(searchString))
            {
                customerDTOs = customService.GetCustomersWhere(searchString);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, CustomerViewModel>()).CreateMapper();
            var customers = mapper.Map<IEnumerable<CustomerDTO>, List<CustomerViewModel>>(customerDTOs);
            return View(customers.AsQueryable());
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var models = customService.GetCustomersWhere(term);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            CustomerDTO customer = customService.GetCustomer(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, CustomerViewModel>()).CreateMapper();
            var customView = mapper.Map<CustomerViewModel>(customer);
            return View(customView);
        }

        public ActionResult Create()
        {
            var newCustomer = new CustomerViewModel();
            return View(newCustomer);
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
              
                var custom = new CustomerDTO
                {
                    CustomerFirstName = viewModel.CustomerFirstName,
                    CustomerLastName = viewModel.CustomerLastName,
                    CompanyName = viewModel.CompanyName,
                    CompanyAddress = viewModel.CompanyAddress,
                    CustomerDescript = viewModel.CustomerDescript
                };

                customService.AddCustom(custom);

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
            CustomerDTO custom = customService.GetCustomer(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, CustomerViewModel>()).CreateMapper();
            var customView = mapper.Map<CustomerViewModel>(custom);

            return View(customView);
        }

        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewModel, CustomerDTO>()).CreateMapper();
                var customView = mapper.Map(viewModel, customService.GetCustomer(id));

                customService.UpdateCustom(customView);


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
            CustomerDTO customer = customService.GetCustomer(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, CustomerViewModel>()).CreateMapper();
            var customView = mapper.Map<CustomerDTO, CustomerViewModel>(customer);
            return View(customView);
        }

        [HttpPost]
        public ActionResult Delete(int id, CustomerViewModel viewModel)
        {
            try
            {
                customService.DeleteCustom(id);
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
            customService.Dispose();
            base.Dispose(disposing);
        }
    }
}