using System.ComponentModel.DataAnnotations;

namespace MovieRentalSystem.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
