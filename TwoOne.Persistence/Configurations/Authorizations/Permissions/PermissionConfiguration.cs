using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TwoOne.Domain.Entities.Authorizations.Permissions;

namespace TwoOne.Persistence.Configurations.Authorizations.Permissions;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions" , "admin");
        builder.HasKey(p => p.Id);
    }
}