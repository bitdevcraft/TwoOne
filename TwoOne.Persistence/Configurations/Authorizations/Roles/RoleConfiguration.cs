using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TwoOne.Domain.Entities.Authorizations.Roles;

namespace TwoOne.Persistence.Configurations.Authorizations.Roles;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "admin");
        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .IsRequired(false);

        // Auditable
        builder.HasOne(u => u.CreatedBy)
            .WithOne()
            .HasForeignKey<Role>(x => x.CreatedById)
            .IsRequired(false);
        
        builder.HasOne(u => u.UpdatedBy)
            .WithOne()
            .HasForeignKey<Role>(x => x.UpdatedById)
            .IsRequired(false);
        
        builder.HasOne(u => u.DeletedBy)
            .WithOne()
            .HasForeignKey<Role>(x => x.DeletedById)
            .IsRequired(false);
    }
}