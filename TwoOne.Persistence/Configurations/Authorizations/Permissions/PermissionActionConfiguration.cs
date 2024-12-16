using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwoOne.Domain.Entities.Authorizations.Permissions;

namespace TwoOne.Persistence.Configurations.Authorizations.Permissions;

public class PermissionActionConfiguration : IEntityTypeConfiguration<PermissionAction>
{
    public void Configure(EntityTypeBuilder<PermissionAction> builder)
    {
        builder.ToTable("PermissionActions", "admin");
        builder.HasKey(pa => pa.Id);
    }
}
