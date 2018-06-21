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
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService serv)
        {
            employeeService = serv;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.SurnameSortParm = sortOrder == "LastName" ? "LastName desc" : "LastName";
            IQueryable<EmployeeDTO> employeeDTOs = employeeService.GetEmployeesOrder(sortOrder);
            if (!String.IsNullOrEmpty(searchString))
            {
                employeeDTOs = employeeService.GetEmployeesWhere(searchString);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var customers = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTOs);
            return View(customers.AsQueryable());
        }

        public ActionResult Details(int id)
        {
            EmployeeDTO employee = employeeService.GetEmployee(id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var customView = mapper.Map<EmployeeViewModel>(employee);
            return View(customView);
        }

        public ActionResult Create()
        {
            var newEmployee = new EmployeeViewModel();
            return View(newEmployee);
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                // Mapper.Initialize(cfg => cfg.CreateMap<CustomerDTO, CustomerViewModel>());
                //  var customer = Mapper.Map<CustomerDTO>(viewModel);
                // viewModel.NewVacancy.ToList().ForEach(x => customer.Vacancies.Add(vacancyService.))

                var employee = new EmployeeDTO
                {
                    EmployeeFirstName = viewModel.EmployeeFirstName,
                    EmployeeLastName = viewModel.EmployeeLastName,
                    EmployeeAddress = viewModel.EmployeeAddress,
                    Unemplyed = true
                };

                employeeService.AddEmployee(employee);

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
            EmployeeDTO employee = employeeService.GetEmployee(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var employeeView = mapper.Map<EmployeeViewModel>(employee);

            return View(employeeView);
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, EmployeeDTO>()).CreateMapper();
                var emplView = mapper.Map(viewModel, employeeService.GetEmployee(id));

                employeeService.UpdateEmployee(emplView);


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
            EmployeeDTO employee = employeeService.GetEmployee(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var emplView = mapper.Map<EmployeeDTO, EmployeeViewModel>(employee);
            return View(emplView);
        }

        [HttpPost]
        public ActionResult Delete(int id, EmployeeViewModel viewModel)
        {
            try
            {
                employeeService.DeleteEmployee(id);
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
            employeeService.Dispose();
            base.Dispose(disposing);
        }
    }
}