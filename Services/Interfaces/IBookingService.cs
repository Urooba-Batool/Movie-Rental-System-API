using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IBookingService
    {
        List<Bookings> GetBooking();

        Bookings? GetBookingById(int id);
        Bookings AddBooking(Bookings addBooking);
        Bookings? UpdateBooking(int id, Bookings updateBooking);
        Bookings? PatchBooking(int id, Bookings updateBooking);
    }
}
