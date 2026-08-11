using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IUserService
    {
        List<Users> GetUsers();
        Users? GetUsersById(int id);
        Users? UpdateUsers(int id, Users updateUsers);
        Users? PatchUsers(int id, Users updateUsers);
        Users AddUsers(Users addUsers);
    }
}
