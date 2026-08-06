using System.ComponentModel.DataAnnotations;

namespace MovieRentalSystem.Models
{
    public class BookingStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
}
