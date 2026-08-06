using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalSystem.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;

        [ForeignKey("CustomerStatus")]
        public int CustomerStatusId { get; set; }
    }
}
