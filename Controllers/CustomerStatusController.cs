using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerStatusController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public CustomerStatusController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCustomerStatus()
        {
            var customerStatus = _context.CustomerStatus.ToList();
            return Ok(customerStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerStatusById(int id)
        {
            var customerStatus = _context.CustomerStatus.Find(id);
            if (customerStatus == null)
            {
                return NotFound();
            }
            return Ok(customerStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomerStatus(int id, CustomerStatus updateCustomerStatus)
        {
            var customerStatus = _context.CustomerStatus.Find(id);
            if(customerStatus == null)
            {
                return NotFound();
            }
            customerStatus.StatusName = updateCustomerStatus.StatusName;
            _context.SaveChanges();
            return Ok(customerStatus);
        }

        [HttpPost]
        public ActionResult AddCustomerStatus(CustomerStatus customerStatus)
        {
            _context.CustomerStatus.Add(customerStatus);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomerStatusById), new { id = customerStatus.Id }, customerStatus);
        }

        [HttpPatch]
        public ActionResult PatchCustomerStatus(int id, CustomerStatus patchCustomerStatus)
        {
            var customerStatus = _context.CustomerStatus.Find(id);
            if (customerStatus == null)
            {
                return NotFound();
            }
            customerStatus.StatusName = patchCustomerStatus.StatusName;
            _context.SaveChanges();
            return Ok(customerStatus);
        }
    }
}
