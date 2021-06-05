using CustomerManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }


        //Get all Customers
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        //Get an individual Customer
        public async Task<Customer> GetCustomer(int CustomerId)
        {
            return await context.Customers.FirstOrDefaultAsync(e => e.Id == CustomerId);
        }

        //Add a new Customers
        public async Task<Customer> AddCustomer(Customer Customer)
        {
            var result = await context.Customers.AddAsync(Customer);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        //Update a Customer
        public async Task<Customer> UpdateCustomer(Customer Customer)
        {
            var result = await context.Customers.FirstOrDefaultAsync(e => e.Id == Customer.Id);

            if (result != null)
            {
                result.Name = Customer.Name;
                result.Email = Customer.Email;
                result.Document= Customer.Document;
                result.Phone= Customer.Phone;
                await context.SaveChangesAsync();

                return result;
            }
            return null;
        }

     
        //Get a Customer by Email
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await context.Customers.FirstOrDefaultAsync(e => e.Email == email);
        }


        //Delete a Customer
        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var result = await context.Customers.FirstOrDefaultAsync(e => e.Id == customerId);
           
            if (result != null)
            {
                context.Customers.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Customer>> Search(string searchName)
        {
            IQueryable<Customer> query = context.Customers;

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(c => c.Name.ToLower().Contains(searchName.ToLower()));

            }
            return await query.ToListAsync();
        }

    }
}