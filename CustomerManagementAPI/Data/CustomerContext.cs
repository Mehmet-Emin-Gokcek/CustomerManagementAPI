using CustomerManagementAPI.Models;
using CustomerManagementAPI.Services;
using Microsoft.EntityFrameworkCore;


namespace CustomerManagementAPI.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        private readonly CustomerService CustomerService; //Customer service will generate and return array of Customer objects

        public CustomerContext(DbContextOptions<CustomerContext> options, CustomerService CustomerService) : base(options)
        {
            this.CustomerService = CustomerService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<Customer>().HasData(CustomerService.GetAll());

            base.OnModelCreating(modelBuilder);
        }
    }
}
