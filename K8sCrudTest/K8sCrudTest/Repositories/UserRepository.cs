using K8sCrudTest.Models;


namespace K8sCrudTest
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
