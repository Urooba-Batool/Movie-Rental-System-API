using System.ComponentModel.DataAnnotations;

namespace MovieRentalSystem.Models
{
    public class MovieGenres
    {
        [Key]
        public int Id { get; set; }
        public string movieGenre { get; set; } = null!;
    }
}
