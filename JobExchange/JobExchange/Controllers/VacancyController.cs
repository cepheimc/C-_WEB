using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobExchange.BLL.Infrastructure;
using JobExchange.BLL.Interfaces;
using JobExchange.BLL.DTO;
using JobExchange.Models;
using AutoMapper;

namespace JobExchange.Controllers
{
    public class VacancyController : Controller
    {
        IVacancyService vacancyService;
        ICategoryService categoryService;
        ICustomService customService;
        public VacancyController(IVacancyService vacancy, ICustomService customer, ICategoryService category)
        {
            vacancyService = vacancy;
            categoryService = category;
            customService = customer;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";           
           IQueryable<VacancyDTO> vacancyDTOs = vacancyService.GetVacanciesOrder(sortOrder);
           if (!String.IsNullOrEmpty(searchString))
            {
                vacancyDTOs = vacancyService.GetVacanciesWhere(searchString);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VacancyDTO, VacancyViewModel>()).CreateMapper();
            var vacancies = mapper.Map<IEnumerable<VacancyDTO>, List<VacancyViewModel>>(vacancyDTOs);
            return View(vacancies.AsQueryable());
        }

        public ActionResult Details(int id)
        {
            VacancyDTO vacancy = vacancyService.GetVacancy(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VacancyDTO, VacancyViewModel>()).CreateMapper();
            var vacancyView = mapper.Map<VacancyViewModel>(vacancy);
            return View(vacancyView);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "CategoryId", "CategoryName");
            ViewBag.CustomerId = new SelectList(customService.GetCustomers(), "CustomerId", "CustomerFirstName");

            var newVacancy = new VacancyViewModel();
            return View(newVacancy);
        }

        [HttpPost]
        public ActionResult Create(VacancyViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var vacancy = new VacancyDTO
                {
                    VacancyName = viewModel.VacancyName,
                    VacancyDescript = viewModel.VacancyDescript,
                    CustomerId = viewModel.CustomerId,
                    CategoryId = viewModel.CategoryId
                };

                vacancyService.AddVacancy(vacancy);

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
            VacancyDTO vacancy = vacancyService.GetVacancy(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VacancyDTO, VacancyViewModel>()).CreateMapper();
            var vacancyView = mapper.Map<VacancyViewModel>(vacancy);
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", vacancyView.CategoryId);
            ViewBag.CustomerId = new SelectList(customService.GetCustomers(), "CustomerId", "CustomerLastName", vacancyView.CustomerId);

            return View(vacancyView);
        }

        [HttpPost]
        public ActionResult Edit(int id, VacancyViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VacancyViewModel, VacancyDTO>()).CreateMapper();
                var vacancyView = mapper.Map(viewModel, vacancyService.GetVacancy(id));

                vacancyService.UpdateVacancy(vacancyView);


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
            VacancyDTO vacancy = vacancyService.GetVacancy(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VacancyDTO, VacancyViewModel>()).CreateMapper();
            var vacancyView = mapper.Map<VacancyDTO, VacancyViewModel>(vacancy);
            return View(vacancyView);
        }

        [HttpPost]
        public ActionResult Delete(int id, VacancyViewModel viewModel)
        {
            try
            {
                vacancyService.DeleteVacancy(id);
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
            vacancyService.Dispose();
            base.Dispose(disposing);
        }
    }
}