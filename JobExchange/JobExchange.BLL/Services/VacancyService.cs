using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using JobExchange.DAL.Entities;
using JobExchange.DAL.Interfaces;
using JobExchange.BLL.DTO;
using JobExchange.BLL.Infrastructure;
using JobExchange.BLL.Interfaces;

namespace JobExchange.BLL.Services
{
    public class VacancyService : IVacancyService
    {
        IUnitOfWork Database { get; set; }

        public VacancyService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddVacancy(VacancyDTO vacancyDTO)
        {
            Customer customer = Database.Customers.Get(vacancyDTO.CustomerId);

            if (customer == null)
                throw new ValidationException("Вакансия не найдена", "");

            Vacancy vacancy = new Vacancy
            {
                Date = DateTime.Now,
                VacancyName = vacancyDTO.VacancyName,
                CustomerId = customer.CustomerId,
                VacancyDescript = vacancyDTO.VacancyDescript,
                CategoryId = vacancyDTO.CategoryId
            };
            Database.Vacancies.Create(vacancy);
            Database.Save();
        }

        public void UpdateVacancy(VacancyDTO vacancyDTO)
        {
            Vacancy vacancy = Database.Vacancies.Get(vacancyDTO.VacancyId);
            if (vacancy == null)
                throw new ValidationException("Вакансия не найдена", "");

            vacancy.VacancyName = vacancyDTO.VacancyName;
            vacancy.VacancyDescript = vacancyDTO.VacancyDescript;
            vacancy.CustomerId = vacancyDTO.CustomerId;
            vacancy.Date = DateTime.Now;
            vacancy.CategoryId = vacancyDTO.CategoryId;

            Database.Vacancies.Update(vacancy);
            Database.Save();
        }

        public void DeleteVacancy(int id)
        {
            Database.Vacancies.Delete(id);
            Database.Save();
        }

        public IQueryable<VacancyDTO> GetVacancies()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vacancy, VacancyDTO>()).CreateMapper();
            var vacancies = mapper.Map<IEnumerable<Vacancy>, List<VacancyDTO>>(Database.Vacancies.GetAll());
            return vacancies.AsQueryable();
        }

        public IQueryable<VacancyDTO> GetVacanciesWhere(string search)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vacancy, VacancyDTO>()).CreateMapper();
            var vacancies = mapper.Map<IEnumerable<Vacancy>, List<VacancyDTO>>(Database.Vacancies.Where(search));
            return vacancies.AsQueryable();
        }

        public IQueryable<VacancyDTO> GetVacanciesOrder(string sort)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vacancy, VacancyDTO>()).CreateMapper();
            if (sort == "Name desc")
            {
                var vacancies = mapper.Map<IEnumerable<Vacancy>, List<VacancyDTO>>(Database.Vacancies.OrderByDecName());
                return vacancies.AsQueryable();
            }
            else
            {
                var vacancies = mapper.Map<IEnumerable<Vacancy>, List<VacancyDTO>>(Database.Vacancies.OrderByName());
                return vacancies.AsQueryable();
            }
        }

        public VacancyDTO GetVacancy(int id)
        {
            var vacancy = Database.Vacancies.Get(id);
            var category = Database.Categories.Get(vacancy.CategoryId);
            var customer = Database.Customers.Get(vacancy.CustomerId);
            if (vacancy == null)
                throw new ValidationException("Вакансия не найдена", "");

            return new VacancyDTO
            {
                VacancyId = vacancy.VacancyID,
                VacancyName = vacancy.VacancyName,
                VacancyDescript = vacancy.VacancyDescript,
                CategoryId = vacancy.CategoryId,
                CustomerId = vacancy.CustomerId,
                Date = vacancy.Date,
                CategoryName = category.CategoryName,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                Company = customer.CompanyName                
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
