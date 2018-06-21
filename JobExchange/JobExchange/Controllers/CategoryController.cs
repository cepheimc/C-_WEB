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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService serv)
        {
            categoryService = serv;
        }

        // GET: Category
        public ActionResult Index()
        {
            IQueryable<CategoryDTO> categoryDTO = categoryService.GetCategories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(categoryDTO);
            return View(categories.AsQueryable());
        }

        protected override void Dispose(bool disposing)
        {
            categoryService.Dispose();
            base.Dispose(disposing);
        }
    }
}