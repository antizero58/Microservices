using Microsoft.EntityFrameworkCore;

namespace K8sCrudTest
{
    class BaseRepositoryContext : IRepositoryContext
    {
        public DbContext DataContext { get; }

        public BaseRepositoryContext(AppDbContext dataContext)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }
}
