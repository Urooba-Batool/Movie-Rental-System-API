using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IRoleService
    {
        List<Roles> GetRoles();
        Roles? GetRolesById(int id);
        Roles? UpdateRoles(int id,  Roles updateRole);
        Roles? PatchRoles(int id, Roles updateRole);
        Roles AddRoles(Roles addRoles);
    }
}
