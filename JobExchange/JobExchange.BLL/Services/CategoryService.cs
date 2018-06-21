using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JobExchange.DAL.Interfaces;
using JobExchange.BLL.DTO;
using JobExchange.BLL.Infrastructure;
using JobExchange.BLL.Interfaces;
using JobExchange.DAL.Entities;

namespace JobExchange.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IQueryable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
            return categories.AsQueryable();
        }

        public CategoryDTO GetCategory(int id)
        {            
            var category = Database.Categories.Get(id);
            if (category == null)
                throw new ValidationException("Категория не найдена", "");

            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
