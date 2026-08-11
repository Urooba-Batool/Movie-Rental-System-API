using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models.DTO;
using MovieRentalSystem.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;
        private readonly IJwtService _jwtService;


        public AuthController(MovieRentalSystemContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var users = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == login.email);

            if(users == null)
            {
                return Unauthorized("Invalid Username or password");
            }

            if (users.Password != login.password)
            {
                return Unauthorized("Invalid Username or password");
            }

            var token = _jwtService.generateToken(users);
            return Ok(new
                {
                    token = token
                }
            );
        }
    }
}
