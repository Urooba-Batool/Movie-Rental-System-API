using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class UserService : IUserService
    {
        private readonly MovieRentalSystemContext _context;

        public UserService(MovieRentalSystemContext context)
        {
            _context = context;
        }

        public List<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public Users? GetUsersById(int id)
        {
            return _context.Users.Find(id);
        }

        public Users? UpdateUsers(int id, Users updateUsers)
        {
            var user = _context.Users.Find(id);
            user.FirstName = updateUsers.FirstName;
            user.LastName = updateUsers.LastName;
            user.Email = updateUsers.Email;
            user.Password = updateUsers.Password;
            user.RoleId = updateUsers.RoleId;
            _context.SaveChanges();

            return user;
        }

        public Users? PatchUsers(int id, Users updateUsers)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(updateUsers.FirstName))
            {
                user.FirstName = updateUsers.FirstName;
            }
            if (!string.IsNullOrEmpty(updateUsers.LastName))
            {
                user.LastName = updateUsers.LastName;
            }
            if (!string.IsNullOrEmpty(updateUsers.Email))
            {
                user.Email = updateUsers.Email;
            }
            if (!string.IsNullOrEmpty(updateUsers.Password))
            {
                user.Password = updateUsers.Password;
            }
            if (updateUsers.RoleId != 0)
            {
                user.RoleId = updateUsers.RoleId;
            }
            _context.SaveChanges();

            return user;

        }

        public Users AddUsers(Users addUsers)
        {
            _context.Users.Add(addUsers);
            _context.SaveChanges();
            return addUsers;
        }
    }
}
