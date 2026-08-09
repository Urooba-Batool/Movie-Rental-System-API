using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services
{
    public interface IJwtService
    {
        string generateToken(Users user);
    }
}
