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
    public class ResumeController : Controller
    {
        IResumeService resumeService;
        IEmployeeService employeeService;
        ICategoryService categoryService;
        public ResumeController(IResumeService resume, IEmployeeService employee, ICategoryService category)
        {
            resumeService = resume;
            employeeService = employee;
            categoryService = category;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            IQueryable<ResumeDTO> resumeDTOs = resumeService.GetResumesOrder(sortOrder);
            if (!String.IsNullOrEmpty(searchString))
            {
                resumeDTOs = resumeService.GetResumesWhere(searchString);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDTO, ResumeViewModel>()).CreateMapper();
            var resumes = mapper.Map<IEnumerable<ResumeDTO>, List<ResumeViewModel>>(resumeDTOs);
            return View(resumes.AsQueryable());
        }

        public ActionResult Details(int id)
        {
            ResumeDTO resume = resumeService.GetResume(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDTO,ResumeViewModel>()).CreateMapper();
            var resumeView = mapper.Map<ResumeViewModel>(resume);
            return View(resumeView);
        }

        
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "CategoryId", "CategoryName");
            ViewBag.EmployeeId = new SelectList(employeeService.GetEmployees(), "EmployeeId", "EmployeeLastName","EmployeeFirstName");

            var newResume = new ResumeViewModel();
            return View(newResume);
        }

        [HttpPost]
        public ActionResult Create(ResumeViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                               
                var resume = new ResumeDTO
                {
                    ResumeName = viewModel.ResumeName,
                    ResumeDescript = viewModel.ResumeDescript,
                    EmployeeId = viewModel.EmployeeId,
                    CategoryId = viewModel.CategoryId
                };

                resumeService.AddResume(resume);

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
            ResumeDTO resume = resumeService.GetResume(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDTO, ResumeViewModel>()).CreateMapper();
            var resumeView = mapper.Map<ResumeViewModel>(resume);
            ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", resumeView.CategoryId);
            ViewBag.EmployeeId = new SelectList(employeeService.GetEmployees(), "EmployeeId", "EmployeeLastName", resumeView.EmployeeId);

            return View(resumeView);
        }

        [HttpPost]
        public ActionResult Edit(int id, ResumeViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeViewModel, ResumeDTO>()).CreateMapper();
                var resumeView = mapper.Map(viewModel, resumeService.GetResume(id));
              // ViewBag.CategoryId = new SelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", resumeView.CategoryId); 
               // ViewBag.EmployeeId = new SelectList(employeeService.GetEmployees(), "EmployeeId", "EmployeeLastName", resumeView.EmployeeId); 

                resumeService.UpdateResume(resumeView);


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
            ResumeDTO resume = resumeService.GetResume(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDTO, ResumeViewModel>()).CreateMapper();
            var resumeView = mapper.Map<ResumeDTO, ResumeViewModel>(resume);
            return View(resumeView);
        }

        [HttpPost]
        public ActionResult Delete(int id, ResumeViewModel viewModel)
        {
            try
            {
                resumeService.DeleteResume(id);
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
            resumeService.Dispose();
            base.Dispose(disposing);
        }
    }
}