using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public CustomersController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var customers = _context.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customers updateCustomer)
        {
            var customers = _context.Customers.Find(id);
            if(customers == null)
            {
                return NotFound();
            }
            customers.FirstName= updateCustomer.FirstName;
            customers.LastName= updateCustomer.LastName;
            customers.Email= updateCustomer.Email;
            customers.Age= updateCustomer.Age;
            customers.Address= updateCustomer.Address;
            _context.SaveChanges();
            return Ok(customers);
        }

        [HttpPost]
        public ActionResult AddCustomers(Customers addCustomers)
        {
            _context.Customers.Add(addCustomers);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomerById), new { id = addCustomers.CustomerId }, addCustomers);
        }

        [HttpPatch]
        public ActionResult PatchCustomers(int id, Customers patchCustomer)
        {
            var customers = _context.Customers.Find(id);
            if(customers == null)
            {
                return NotFound();
            }
            if(!string.IsNullOrEmpty(patchCustomer.FirstName))
            {
                customers.FirstName = patchCustomer.FirstName;
            }
            if(!string.IsNullOrEmpty(patchCustomer.LastName))
            {
                customers.LastName = patchCustomer.LastName;
            }
            if(!string.IsNullOrEmpty(patchCustomer.Email))
            {
                customers.Email = patchCustomer.Email;
            }
            if(patchCustomer.Age != 0)
            {
                customers.Age = patchCustomer.Age;
            }
            if(!string.IsNullOrEmpty(patchCustomer.Address))
            {
                customers.Address = patchCustomer.Address;
            }
            _context.SaveChanges();
            return Ok(customers);
        }


    }
}
