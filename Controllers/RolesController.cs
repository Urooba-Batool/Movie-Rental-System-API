using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public RolesController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult GetRolesById(int id)
        {
            var roles = _context.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpPost]
        public ActionResult CreateRoles(Roles createRoles)
        {
            _context.Roles.Add(createRoles);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRolesById), new { id = createRoles.RoleId }, createRoles);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRoles(int id, Roles updateRoles)
        {
            var roles = _context.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }
            roles.RoleName = updateRoles.RoleName;
            _context.SaveChanges();
            return Ok(roles);
        }

        [HttpPatch]
        public ActionResult PatchRoles(int id, Roles patchRoles)
        {
            var roles = _context.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(patchRoles.RoleName))
            {
                roles.RoleName = patchRoles.RoleName;
            }
            _context.SaveChanges();
            return NoContent();
        }

    }
}
