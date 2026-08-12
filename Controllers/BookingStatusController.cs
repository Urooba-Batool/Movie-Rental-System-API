using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingStatusController : ControllerBase
    {
        private readonly IBookingStatusService _bookingStatusService;

        public BookingStatusController(IBookingStatusService bookingStatusService)
        {
            _bookingStatusService = bookingStatusService;
        }

        [HttpGet]
        public ActionResult GetBookingStatus()
        {
            var bookingStatus = _bookingStatusService.GetBookingStatus();
            return Ok(bookingStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingStatusById(int id)
        {
            var bookingStatus = _bookingStatusService.GetBookingStatusById(id);
            return Ok(bookingStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookingStatus(int id, BookingStatus updateBookingStatus)
        {
            var bookingStatus = _bookingStatusService.UpdateBookingStatus(id, updateBookingStatus);
            return Ok(bookingStatus);
        }

        [HttpPost]
        public ActionResult AddBookingStatus(BookingStatus bookingStatus)
        {
            _bookingStatusService.AddBookingStatus(bookingStatus);
            return CreatedAtAction(nameof(GetBookingStatusById), new { id = bookingStatus.Id }, bookingStatus);
        }

        [HttpPatch]
        public ActionResult PatchBookingStatus(int id, BookingStatus patchBookingStatus)
        {
            var bookingStatus = _bookingStatusService.PatchBookingStatus(id, patchBookingStatus);
            return Ok(bookingStatus);
        }
    }
}
