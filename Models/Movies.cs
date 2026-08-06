using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalSystem.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string MovieTitle { get; set; } = null!;
        public string Director { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public double RentalPrice { get; set; }

        [ForeignKey("MovieGenres")]
        public int MovieGenreId { get; set; }
        [ForeignKey("MovieStatus")]
        public int MovieStatusId { get; set; }  
    }
}
