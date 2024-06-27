using UsersManagementConsist.Model;

namespace User_sManagementConsist.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(int userId);
        bool ValidateUser(string userName, string userPassword);

        IEnumerable<User> GetUsers();
    }
}
