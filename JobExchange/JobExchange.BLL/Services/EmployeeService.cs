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
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork Database { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {

            Employee employee = new Employee
            {
                EmployeeFirstName = employeeDTO.EmployeeFirstName,
                EmployeeLastName = employeeDTO.EmployeeLastName,
                EmployeeAddress = employeeDTO.EmployeeAddress,
                Unemplyed = true                
            };
            Database.Employees.Create(employee);
            Database.Save();
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = Database.Employees.Get(employeeDTO.EmployeeId);
            if (employee == null)
                throw new ValidationException("Человек не найден", "");

            employee.EmployeeFirstName = employeeDTO.EmployeeFirstName;
            employee.EmployeeLastName = employeeDTO.EmployeeLastName;
            employee.EmployeeAddress = employeeDTO.EmployeeAddress;

            Database.Employees.Update(employee);
            Database.Save();
        }

        public void DeleteEmployee(int id)
        {
            Database.Employees.Delete(id);
            Database.Save();
        }

        public IQueryable<EmployeeDTO> GetEmployees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            var employees = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
            return employees.AsQueryable();
        }

        public IQueryable<EmployeeDTO> GetEmployeesWhere(string search)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            var employees = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.Where(search));
            return employees.AsQueryable();
        }

        public IQueryable<EmployeeDTO> GetEmployeesOrder(string sort)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            if (sort == "Name desc")
            {
                var employees = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.OrderByDecName());
                return employees.AsQueryable();
            }
            if (sort == "LastName desc")
            {
                var employees = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.OrderByDecSurName());
                return employees.AsQueryable();
            }
            if (sort == "LastName")
            {
                var employees = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.OrderBySurName());
                return employees.AsQueryable();
            }
            else
            {
                var employees = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.OrderByName());
                return employees.AsQueryable();
            }

        }

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = Database.Employees.Get(id);
            if (employee == null)
                throw new ValidationException("Человек не найден", "");

            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName,
                EmployeeAddress = employee.EmployeeAddress,
                Unemplyed = employee.Unemplyed
            };
        }       

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
