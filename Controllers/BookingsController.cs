using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;
        public BookingsController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetBookings()
        {
            var bookings = _context.Bookings.ToList();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingsById(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookings(int id, Bookings updateBookings)
        {
            var bookings = _context.Bookings.Find(id);
            if(bookings == null)
            {
                return NotFound();
            }
            bookings.BookingDate = updateBookings.BookingDate;
            bookings.ReturnDate = updateBookings.ReturnDate;
            bookings.TotalPrice = updateBookings.TotalPrice;
            bookings.TotalDays = updateBookings.TotalDays;
            bookings.CustomerId = updateBookings.CustomerId;
            bookings.UserId = updateBookings.UserId;
            bookings.MovieId = updateBookings.MovieId;
            bookings.BookingStatusId = updateBookings.BookingStatusId;
            _context.SaveChanges();
            return Ok(bookings);
        }

        [HttpPost]
        public ActionResult AddBooking(int id, Bookings addBookings)
        {
            _context.Bookings.Add(addBookings);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBookingsById), new { id = addBookings.Id }, addBookings);
        }

        [HttpPatch]
        public ActionResult PatchBookings(int id, Bookings patchBookings)
        {
            var bookings = _context.Bookings.Find(id);
            if(bookings == null)
            {
                return NotFound();
            }
            bookings.BookingDate = patchBookings.BookingDate;
            bookings.ReturnDate = patchBookings.ReturnDate;
            bookings.TotalPrice = patchBookings.TotalPrice;
            bookings.TotalDays = patchBookings.TotalDays;
            bookings.CustomerId = patchBookings.CustomerId;
            bookings.UserId = patchBookings.UserId;
            bookings.MovieId = patchBookings.MovieId;
            bookings.BookingStatusId = patchBookings.BookingStatusId;
            _context.SaveChanges();
            return Ok(bookings);
        }
    }
}
