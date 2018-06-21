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
    public class ResumeService : IResumeService
    {
        IUnitOfWork Database { get; set; }

        public ResumeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddResume(ResumeDTO resumeDTO)
        {
            Employee employee = Database.Employees.Get(resumeDTO.EmployeeId);

            if (employee == null)
                throw new ValidationException("Чуловек не найден", "");

            Resume resume = new Resume
            {
                Date = DateTime.UtcNow,
                ResumeName = resumeDTO.ResumeName,
                EmployeeId = employee.EmployeeId,
                ResumeDescript = resumeDTO.ResumeDescript,
                CategoryId = resumeDTO.CategoryId
            };
            Database.Resumes.Create(resume);
            Database.Save();
        }

        public void UpdateResume(ResumeDTO resumeDTO)
        {
            Resume resume = Database.Resumes.Get(resumeDTO.ResumeId);
            if (resume == null)
                throw new ValidationException("Резюме не найдено", "");

            resume.ResumeName = resumeDTO.ResumeName;
            resume.ResumeDescript = resumeDTO.ResumeDescript;
            resume.EmployeeId = resumeDTO.EmployeeId;
            resume.Date = DateTime.Now;
            resume.CategoryId = resumeDTO.CategoryId;
           // resume.Employee.EmployeeId = resumeDTO.Employee.EmployeeId;

            Database.Resumes.Update(resume);
            Database.Save();
        }

        public void DeleteResume(int id)
        {
            Database.Resumes.Delete(id);
            Database.Save();
        }

        public IQueryable<ResumeDTO> GetResumes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Resume, ResumeDTO>()).CreateMapper();
            var resume = mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(Database.Resumes.GetAll());
            return resume.AsQueryable();
        }

        public IQueryable<ResumeDTO> GetResumesWhere(string search)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Resume, ResumeDTO>()).CreateMapper();
            var resume = mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(Database.Resumes.Where(search));
            return resume.AsQueryable();
        }

        public IQueryable<ResumeDTO> GetResumesOrder(string sort)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Resume, ResumeDTO>()).CreateMapper();
            if (sort == "Name desc")
            {
                var resume = mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(Database.Resumes.OrderByDecName());
                return resume.AsQueryable();
            }
            else
            {
                var resume = mapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(Database.Resumes.OrderByName());
                return resume.AsQueryable();
            }
        }

            public ResumeDTO GetResume(int id)
        {            
            var resume = Database.Resumes.Get(id);
            var category = Database.Categories.Get(resume.CategoryId);
            var employee = Database.Employees.Get(resume.EmployeeId);
            if (resume == null)
                throw new ValidationException("Резюме не найдено", "");

            return new ResumeDTO
            {
                ResumeId = resume.ResumeId,
                ResumeName = resume.ResumeName,
                ResumeDescript = resume.ResumeDescript,
                EmployeeId = resume.EmployeeId,
                CategoryId = resume.CategoryId,
                Date = resume.Date,
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                CategoryName = category.CategoryName
            };
        }       

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
