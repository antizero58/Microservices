using K8sCrudTest.Models;

namespace K8sCrudTest
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository brokerRepository)
        {
            _userRepository = brokerRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.Run(() =>
            {
                return _userRepository.Get().ToList();
            });
        }

        public async Task<User> GetUser(int userId)
        {
            if (_userRepository.Get().Where(r => r.UserId == userId).Count() == 0)
                throw new KeyNotFoundException();

            return await Task.Run(() =>
            {
                return _userRepository.Get().Where(r => r.UserId == userId).FirstOrDefault();
            });
        }

        public async Task CreateUser(string firstName, string secondName)
        {
            var user = new User() { FirstName = firstName, LastName = secondName };
            
            await Task.Run(() => _userRepository.Insert(user));
        }

        public async Task UpdateUser(User user)
        {
            var u = _userRepository.Get().Where(r => r.UserId == user.UserId).FirstOrDefault();
            if (u == null)
                throw new KeyNotFoundException();

            user.InsertUser = u.InsertUser;
            user.InsertDt = u.InsertDt;
            await Task.Run(() => _userRepository.Update(user));
        }

        public async Task DeleteUser(int userId)
        {
            if (_userRepository.Get().Where(r => r.UserId == userId).Count() == 0)
                throw new KeyNotFoundException();

            await Task.Run(() => _userRepository.Delete(userId));
        }
    }
}
