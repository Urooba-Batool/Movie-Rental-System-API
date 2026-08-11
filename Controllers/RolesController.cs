using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            var role = _roleService.GetRoles();
            return Ok(role);
        }

        [HttpGet("{id}")]
        public ActionResult GetRolesById(int id)
        {
            var roles = _roleService.GetRolesById(id);
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpPost]
        public ActionResult AddRoles(Roles addRoles)
        {
            var roles = _roleService.AddRoles(addRoles);
            return CreatedAtAction(nameof(GetRolesById), new { id = addRoles.RoleId }, addRoles);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRoles(int id, Roles updateRoles)
        {
            var roles = _roleService.UpdateRoles(id, updateRoles);
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchRoles(int id, Roles updateRoles)
        {
            var roles = _roleService.PatchRoles(id, updateRoles);
            
            return Ok(roles);
        }

    }
}
