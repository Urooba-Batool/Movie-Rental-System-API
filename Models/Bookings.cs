using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalSystem.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double TotalPrice { get; set; }
        public int TotalDays { get; set; }


        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        [ForeignKey("BookingStatus")]
        public int BookingStatusId { get; set; }
    }
}
