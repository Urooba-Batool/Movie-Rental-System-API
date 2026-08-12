using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly MovieRentalSystemContext _context;
        public BookingService(MovieRentalSystemContext context)
        {
            _context = context;
        }

        public List<Bookings> GetBooking()
        {
            return _context.Bookings.ToList();
        }

        public Bookings? GetBookingById(int id)
        {
            return _context.Bookings.Find(id);
        }

        public Bookings AddBooking(Bookings addBooking)
        {
            _context.Bookings.Add(addBooking);
            _context.SaveChanges();
            return addBooking;
        }

        public Bookings? UpdateBooking(int id, Bookings updateBookings)
        {
            var bookings = _context.Bookings.Find(id);
            if (bookings == null)
            {
                return null;
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
            return bookings;
        }

        public Bookings? PatchBooking(int id, Bookings patchBookings)
        {
            var bookings = _context.Bookings.Find(id);
            if (bookings == null)
            {
                return null;
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
            return bookings;
        }

        
    }
}
