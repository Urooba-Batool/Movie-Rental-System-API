using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetUsersById(int id)
        {
            var user = _userService.GetUsersById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUsers(int id, Users updateuser)
        {   var user = _userService.UpdateUsers(id, updateuser);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddUsers(Users newuser)
        {
            _userService.AddUsers(newuser);
            return CreatedAtAction(nameof(GetUsersById), new { id = newuser.UserId }, newuser);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchUser(int id, Users updateuser)
        {
            var user = _userService.PatchUsers(id, updateuser);
            return Ok(user);
        }

    }
}
