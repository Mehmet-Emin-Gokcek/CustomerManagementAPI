using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int CustomerId);
        Task<Customer> AddCustomer(Customer Customer);
        Task<Customer> UpdateCustomer(Customer Customer);
        Task<Customer> DeleteCustomer(int CustomerId);
        Task<Customer> GetCustomerByEmail(string email);
        Task<IEnumerable<Customer>> Search(string name);


    }
}
