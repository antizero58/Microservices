using K8sCrudTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace K8sCrudTest.ModelTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.InsertUser)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValueSql("(current_user)");

            builder.Property(e => e.InsertDt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasDefaultValueSql("(now())");
        }
    }
}
