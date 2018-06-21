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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //IEnumerable<EmployeeDTO> employeeDTO = resumeService.GetEmployees();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            //var employees = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(employeeDTO);
            return View();
        }
        
    }
}