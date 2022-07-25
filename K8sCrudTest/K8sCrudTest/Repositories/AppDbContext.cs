using K8sCrudTest.Models;
using K8sCrudTest.ModelTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace K8sCrudTest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                :base(options)
        {
        }

        // these properties map to tables in the database 
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // to use Microsoft SQL Server, uncomment the following 
            //optionsBuilder.UseSqlServer(
            //  @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=HardPlus; Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        }
    }
}
