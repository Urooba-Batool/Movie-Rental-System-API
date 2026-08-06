using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public UsersController(MovieRentalSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
