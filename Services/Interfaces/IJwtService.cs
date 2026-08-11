using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IJwtService
    {
        string generateToken(Users user);
    }
}
