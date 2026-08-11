using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IBookingStatusService
    {
        List<BookingStatus> GetBookingStatus();

        BookingStatus? GetBookingStatusById(int id);
        BookingStatus AddBookingStatus(BookingStatus addBookingStatus);
        BookingStatus? UpdateBookingStatus(int id, BookingStatus updateBookingStatus);
        BookingStatus? PatchBookingStatus(int id, BookingStatus updateBookingStatus);
    }
}
