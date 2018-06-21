using System.Linq;
using JobExchange.BLL.DTO;

namespace JobExchange.BLL.Interfaces
{
    public interface ICustomService
    {
        void AddCustom(CustomerDTO customerDTO);
        void UpdateCustom(CustomerDTO customerDTO);
        void DeleteCustom(int id);
        CustomerDTO GetCustomer(int id);
        IQueryable<CustomerDTO> GetCustomers();
        IQueryable<CustomerDTO> GetCustomersOrder(string sort);
        IQueryable<CustomerDTO> GetCustomersWhere(string search);
        void Dispose();
    }
}
