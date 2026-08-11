using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IBookingService
    {
        List<Bookings> GetBooking();

        Bookings? GetBookingById(int id);
        Bookings AddBookingStatus(Bookings addBooking);
        Bookings? UpdateBookingStatus(int id, Bookings updateBooking);
        Bookings? PatchBookingStatus(int id, Bookings updateBooking);
    }
}
