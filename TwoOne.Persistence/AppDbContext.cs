using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwoOne.Domain.Entities.Authorizations.Roles;
using TwoOne.Domain.Entities.Users;
using TwoOne.Persistence.Seeds.DefaultDbData;

namespace TwoOne.Persistence;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User, Role, string>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("app");
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        builder.SeedData();
    }
}
