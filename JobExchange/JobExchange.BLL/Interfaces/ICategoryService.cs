using System.Linq;
using JobExchange.BLL.DTO;

namespace JobExchange.BLL.Interfaces
{
    public interface ICategoryService
    {
        CategoryDTO GetCategory(int id);
        IQueryable<CategoryDTO> GetCategories();
        void Dispose();
    }
}
