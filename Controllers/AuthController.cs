using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public AuthController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var users = _context.Users.FirstOrDefault(u => u.Email == login.email);

            if(users == null)
            {
                return Unauthorized("Invalid Username or password");
            }

            if (users.Password != login.password)
            {
                return Unauthorized("Invalid Username or password");
            }

            return Ok("login successful");
        }
    }
}
