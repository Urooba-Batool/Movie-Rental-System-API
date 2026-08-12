using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult GetBookings()
        {
            var bookings = _bookingService.GetBooking();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingsById(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookings(int id, Bookings updateBookings)
        {
            var bookings = _bookingService.UpdateBooking(id, updateBookings);
            return Ok(bookings);
        }

        [HttpPost]
        public ActionResult AddBooking(int id, Bookings addBookings)
        {
            _bookingService.AddBooking(addBookings);
            return CreatedAtAction(nameof(GetBookingsById), new { id = addBookings.Id }, addBookings);
        }

        [HttpPatch]
        public ActionResult PatchBookings(int id, Bookings patchBookings)
        {
            var bookings = _bookingService.PatchBooking(id, patchBookings);
            return Ok(bookings);
        }
    }
}
