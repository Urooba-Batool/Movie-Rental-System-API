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
    public class CustomerStatusController : ControllerBase
    {
        private readonly ICustomerStatusService _customerStatusService;
        public CustomerStatusController(ICustomerStatusService customerStatusService)
        {
            _customerStatusService = customerStatusService;
        }

        
        [HttpGet]
        public ActionResult GetCustomerStatus()
        {
            var customerStatus = _customerStatusService.GetCustomerStatus();
            return Ok(customerStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerStatusById(int id)
        {
            var customerStatus = _customerStatusService.GetCustomerStatusById(id);
            
            return Ok(customerStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomerStatus(int id, CustomerStatus updateCustomerStatus)
        {
            var customerStatus = _customerStatusService.UpdateCustomerStatus(id, updateCustomerStatus);
            return Ok(customerStatus);
        }

        [HttpPost]
        public ActionResult AddCustomerStatus(CustomerStatus customerStatus)
        {
            _customerStatusService.AddCustomerStatus(customerStatus);
            return CreatedAtAction(nameof(GetCustomerStatusById), new { id = customerStatus.Id }, customerStatus);
        }

        [HttpPatch]
        public ActionResult PatchCustomerStatus(int id, CustomerStatus patchCustomerStatus)
        {
            var customerStatus = _customerStatusService.PatchCustomerStatus(id, patchCustomerStatus);
            return Ok(customerStatus);
        }
    }
}
