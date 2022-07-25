using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace K8sCrudTest
{
    public static class RegistrationModule
    {
        public static void RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseNpgsql(connectionString);
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            services.TryAddScoped<BaseRepositoryContext>();
            services.TryAddScoped<IRepositoryContext, BaseRepositoryContext>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddScoped<IUserService, UserService>();
        }
    }
}
