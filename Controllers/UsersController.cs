using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

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

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, Users updateuser)
        {   var user = _context.Users.Find(id);
            if (id == null)
            {
                return BadRequest();
            }
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = updateuser.FirstName;
            user.LastName = updateuser.LastName;
            user.Email = updateuser.Email;
            user.Password = updateuser.Password;
            user.RoleId = updateuser.RoleId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateUser(Users newuser)
        {
            _context.Users.Add(newuser);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = newuser.UserId }, newuser);
        }

        [HttpPatch]
        public ActionResult PatchUser(int id, Users updateuser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(updateuser.FirstName))
            {
                user.FirstName = updateuser.FirstName;
            }
            if (!string.IsNullOrEmpty(updateuser.LastName))
            {
                user.LastName = updateuser.LastName;
            }
            if (!string.IsNullOrEmpty(updateuser.Email))
            {
                user.Email = updateuser.Email;
            }
            if (!string.IsNullOrEmpty(updateuser.Password))
            {
                user.Password = updateuser.Password;
            }
            if (updateuser.RoleId != 0)
            {
                user.RoleId = updateuser.RoleId;
            }
            _context.SaveChanges();
            return NoContent();
        }

    }
}
