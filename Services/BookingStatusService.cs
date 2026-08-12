using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class BookingStatusService : IBookingStatusService
    {
        private readonly MovieRentalSystemContext _context;

        public BookingStatusService(MovieRentalSystemContext context)
        {
            _context = context;
        }

        public List<BookingStatus> GetBookingStatus()
        {
            return _context.BookingStatus.ToList();
        }

        public BookingStatus? GetBookingStatusById(int id)
        {
            return _context.BookingStatus.Find(id);
        }

        public BookingStatus AddBookingStatus(BookingStatus addBookingStatus)
        {
            _context.BookingStatus.Add(addBookingStatus);
            _context.SaveChanges();
            return addBookingStatus;
        }

        public BookingStatus? UpdateBookingStatus(int id, BookingStatus updateBookingStatus)
        {
            var bookingStatus = _context.BookingStatus.Find(id);
            if (bookingStatus == null)
            {
                return null;
            }
            bookingStatus.StatusName = updateBookingStatus.StatusName;
            _context.SaveChanges();
            return bookingStatus;
        }

        public BookingStatus? PatchBookingStatus(int id, BookingStatus updateBookingStatus)
        {
            var bookingStatus = _context.BookingStatus.Find(id);
            if (bookingStatus == null)
            {
                return null;
            }
            bookingStatus.StatusName = updateBookingStatus.StatusName;
            _context.SaveChanges();
            return bookingStatus;
        }
    }
}
