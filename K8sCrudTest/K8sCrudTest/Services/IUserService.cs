using K8sCrudTest.Models;

namespace K8sCrudTest
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int userId);

        Task CreateUser(string firstName, string secondName);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
