using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingStatusController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public BookingStatusController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetBookingStatus()
        {
            var bookingStatus = _context.BookingStatus.ToList();
            return Ok(bookingStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingStatusById(int id)
        {
            var bookingStatus = _context.BookingStatus.Find(id);
            if(bookingStatus == null)
            { 
                return NotFound(); 
            }
            return Ok(bookingStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookingStatus(int id, BookingStatus updateBookingStatus)
        {
            var bookingStatus = _context.BookingStatus.Find(id);
            if(bookingStatus == null)
            {
                return NotFound();
            }
            bookingStatus.StatusName = updateBookingStatus.StatusName;
            _context.SaveChanges();
            return Ok(bookingStatus);
        }

        [HttpPost]
        public ActionResult AddBookingStatus(BookingStatus bookingStatus)
        {
            _context.BookingStatus.Add(bookingStatus);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBookingStatusById), new { id = bookingStatus.Id }, bookingStatus);
        }

        [HttpPatch]
        public ActionResult PatchBookingStatus(int id, BookingStatus patchBookingStatus)
        {
            var bookingStatus = _context.BookingStatus.Find(id);
            if(bookingStatus == null)
            {
                return NotFound();
            }
            bookingStatus.StatusName = patchBookingStatus.StatusName;
            _context.SaveChanges();
            return Ok(bookingStatus);
        }
    }
}
