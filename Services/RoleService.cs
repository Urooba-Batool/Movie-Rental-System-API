using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly MovieRentalSystemContext _context;

        public RoleService(MovieRentalSystemContext context)
        {
            _context = context;
        }

        public List<Roles> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Roles? GetRolesById(int id)
        {
            return _context.Roles.Find(id);
        }

        public Roles? UpdateRoles(int id, Roles updateRoles)
        {
            var role = _context.Roles.Find(id);
            role.RoleName = updateRoles.RoleName;
            _context.SaveChanges();


            return role;
        }

        public Roles? PatchRoles(int id, Roles updateRole)
        {
            var roles = _context.Roles.Find(id);
            if (roles == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(updateRole.RoleName))
            {
                roles.RoleName = updateRole.RoleName;
            }
            _context.SaveChanges();

            return roles;

        }

        public Roles AddRoles(Roles addRoles)
        {
            _context.Roles.Add(addRoles);
            _context.SaveChanges();
            return addRoles;
        }
    }
}
