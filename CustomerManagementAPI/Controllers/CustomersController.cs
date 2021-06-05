using CustomerManagementAPI.Data;
using CustomerManagementAPI.Models;
using CustomerManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Controllers
{
    //CustomersController class is decorated with ApiController attribute. This attribute allows the data from the request to
    //be mapped to the customer parameter on CreateCustomer() method. Either this ApiController attribute is required or the
    //method parameter must be decorated with [FromBody] attribute. Otherwise, model binding will not work as expected and the
    //customer data from the request will not be mapped to the customer parameter on the CreateCustomer method.
    //public async Task<IActionResult> CreateCustomer([FromBody] Customer customer) {}


    //Model State Valid: No need to explicitly check if the model state is Valid. Since the controller class is decorated with the
    //[ApiController] attribute, it takes care of checking if the model state is valid and automatically
    //returns 400 response along the validation errors.



    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        // GET api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            //The return type of Task<ActionResult> allows us to return status code 200 OK along with
            //the list of customers or status code 500 if there is a server error retrieving data from the database.
            try
            {
                return Ok(await customerRepository.GetCustomers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        //#GET api/Customers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            //If the customer is found, ASP.NET Core automatically serializes the customer object to JSON
            //and writes it into the response body. This response body along with the http status code 200 OK
            //is returned to the client. If the Customer is not found, then http status code 404 NotFound is returned.

            try
            {
                var result = await customerRepository.GetCustomer(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        //#POST api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                    return BadRequest();

                // Add custom model validation error
                var newCustomer = customerRepository.GetCustomerByEmail(customer.Email);

                if (newCustomer != null)
                {
                    ModelState.AddModelError("email", "Customer email already in use");
                    return BadRequest(ModelState);
                }



                var createdCustomer = await customerRepository.AddCustomer(customer);
                //When a new resource or new object is created the following 3 things usually happen:
                //Return the http status code 201 to indicate that the resource is successfully created.
                //Return the newly created resource. In our case, the newly created employee. Add a Location header to the response.
                //The Location header specifies the URI of the newly created employee object.
                //CreatedAtAction method helps us achieve all the above three things. 

                return CreatedAtAction("GetCustomer", new { id = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Customer record");
            }
        }

        //#PUT api/Customers/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateEmployee(int id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                    return BadRequest("Customer ID mismatch");

                var employeeToUpdate = await customerRepository.GetCustomer(id);

                if (employeeToUpdate == null)
                    return NotFound($"Customer with Id = {id} not found");

                return await customerRepository.UpdateCustomer(customer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        //#DELETE api/Customers/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteEmployee(int id)
        {
            try
            {
                var customerToDelete = await customerRepository.GetCustomer(id);

                if (customerToDelete == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }

                return await customerRepository.DeleteCustomer(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }



        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Customer>>> Search(string search)
        {
            Console.WriteLine("Search term passed: " + search);
            try
            {
                var result = await customerRepository.Search(search);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}