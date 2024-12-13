using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TwoOne.Domain.Entities.Users;

namespace TwoOne.Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "admin");
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.CreatedBy)
            .WithOne()
            .HasForeignKey<User>(u => u.CreatedById);
        
        builder.HasOne(u => u.UpdatedBy)
            .WithOne()
            .HasForeignKey<User>(u => u.UpdatedById);
        
        builder.HasOne(u => u.DeletedBy)
            .WithOne()
            .HasForeignKey<User>(u => u.DeletedById);
    }
}