using Microsoft.EntityFrameworkCore;
using User_sManagementConsist.Model;
using UsersManagementConsist.Model;

namespace User_sManagementConsist.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;

        }
        public void CreateUser(User user)
        {
            if(_context.Users.Any(u => u.UserId == user.UserId))
            {
                throw new Exception("the id of  the user exists");
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
               
                
            }
            
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
               
                _context.Users.Remove(user);
                _context.SaveChanges();


            }
            else
            {
                throw new Exception("the id of  the user is not exists");
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();

        }

        public bool ValidateUser(string userName, string userPassword)
        {
            if (userName == null || userPassword == null)
            { return false; }
            else
            {
                return _context.Users.Any(u => u.UserName == userName && u.UserPassword == userPassword);
            }
        }
    }
}
