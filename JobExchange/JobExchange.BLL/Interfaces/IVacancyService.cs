using System.Linq;
using JobExchange.BLL.DTO;

namespace JobExchange.BLL.Interfaces
{
    public interface IVacancyService
    {
        void AddVacancy(VacancyDTO vacancyDTO);
        void UpdateVacancy(VacancyDTO vacancyDTO);
        void DeleteVacancy(int id);
        VacancyDTO GetVacancy(int id);
        IQueryable<VacancyDTO> GetVacancies();
        IQueryable<VacancyDTO> GetVacanciesOrder(string sort);
        IQueryable<VacancyDTO> GetVacanciesWhere(string search);
        void Dispose();
    }
}
