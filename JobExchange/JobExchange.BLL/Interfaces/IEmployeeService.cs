using System.Linq;
using JobExchange.BLL.DTO;

namespace JobExchange.BLL.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDTO employeeDTO);
        void UpdateEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
        EmployeeDTO GetEmployee(int id);
        IQueryable<EmployeeDTO> GetEmployees();
        IQueryable<EmployeeDTO> GetEmployeesOrder(string sort);
        IQueryable<EmployeeDTO> GetEmployeesWhere(string search);
        void Dispose();
    }
}
