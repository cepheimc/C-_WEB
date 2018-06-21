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
    public class CustomerService : ICustomService
    {
        IUnitOfWork Database { get; set; }

        public CustomerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddCustom(CustomerDTO customerDTO)
        {                     

            Customer customer = new Customer
            {
                CustomerFirstName = customerDTO.CustomerFirstName,
                CustomerLastName = customerDTO.CustomerLastName,
                CompanyName = customerDTO.CompanyName,
                CompanyAddress= customerDTO.CompanyAddress,
                CustomerDescript = customerDTO.CustomerDescript
            };
            Database.Customers.Create(customer);
            Database.Save();
        }

        public void UpdateCustom(CustomerDTO customerDTO)
        {
            Customer customer = Database.Customers.Get(customerDTO.CustomerId);
            if (customer == null)
                throw new ValidationException("Человек не найден", "");

            customer.CustomerFirstName = customerDTO.CustomerFirstName;
            customer.CustomerLastName = customerDTO.CustomerLastName;
            customer.CompanyName = customerDTO.CompanyName;
            customer.CompanyAddress = customerDTO.CompanyAddress;
            customer.CustomerDescript = customerDTO.CustomerDescript;

            Database.Customers.Update(customer);
            Database.Save();
        }

        public void DeleteCustom(int id)
        {
            Database.Customers.Delete(id);
            Database.Save();
        }        

        public IQueryable<CustomerDTO> GetCustomers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            var customers = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.GetAll());
            return customers.AsQueryable();
        }

        public IQueryable<CustomerDTO> GetCustomersWhere(string search)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            var customers = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.Where(search));
            return customers.AsQueryable();
        }

        public IQueryable<CustomerDTO> GetCustomersOrder(string sort)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            if (sort == "Name desc")
            {
                var customers = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.OrderByDecName());
                return customers.AsQueryable();
            }
            if (sort == "LastName desc")
            {
                var customers = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.OrderByDecSurName());
                return customers.AsQueryable();
            }
            if (sort == "LastName")
            {
                var customers = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.OrderBySurName());
                return customers.AsQueryable();
            }
            else
            {
                var customers = mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.OrderByName());
                return customers.AsQueryable();
            }           
        }

        public CustomerDTO GetCustomer(int id)
        {           
            var customer = Database.Customers.Get(id);
            if (customer == null)
                throw new ValidationException("Человек не найден", "");

            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CompanyName = customer.CompanyName,
                CompanyAddress = customer.CompanyAddress,
                CustomerDescript = customer.CustomerDescript
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
