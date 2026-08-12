using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customers updateCustomer)
        {
            var customers = _customerService.UpdateCustomers(id, updateCustomer);
            
            return Ok(customers);
        }

        [HttpPost]
        public ActionResult AddCustomers(Customers addCustomers)
        {
            _customerService.AddCustomers(addCustomers);
            return CreatedAtAction(nameof(GetCustomerById), new { id = addCustomers.CustomerId }, addCustomers);
        }

        [HttpPatch]
        public ActionResult PatchCustomers(int id, Customers patchCustomer)
        {
            var customers =_customerService.PatchCustomers(id, patchCustomer);            
            return Ok(customers);
        }


    }
}
