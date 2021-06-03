using CustomerManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Services
{
    public class CustomerService
    {
        private static List<Customer> Customers = new List<Customer>();
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Jonathan", "Mary", "Susan", "Joe", "Paul", "Carl", "Amanda", "Neil" };
        private static readonly string[] surnames = new string[] { "Smith", "O'Neil", "MacDonald", "Gay", "Bailee", "Saigan", "Strip", "Spenser" };
        private static readonly string[] extensions = new string[] { "@gmail.com", "@hotmail.com", "@outlook.com", "@icloud.com", "@yahoo.com" };
        static CustomerService()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                Customer customer = new Customer
                {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + extensions[rnd.Next(extensions.Length)],
                    Document = (rnd.Next(0, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "+1 888-452-1232"
                };

                Customers.Add(customer);
            }
        }
        public List<Customer> GetAll()
        {
            return Customers;
        }
        public Customer GetById(int id)
        {
            return Customers.Where(Customer => Customer.Id == id).FirstOrDefault();
        }
        public Customer Create(Customer customer)
        {
            customer.Id = Count++;
            Customers.Add(customer);
            return customer;
        }
        public void Update(int id, Customer Customer)
        {
            Customer found = Customers.Where(n => n.Id == id).FirstOrDefault();
            found.Name = Customer.Name;
            found.Email = Customer.Email;
            found.Document = Customer.Document;
            found.Phone = Customer.Phone;
        }
        public void Delete(int id)
        {
            Customers.RemoveAll(n => n.Id == id);
        }
    }
}