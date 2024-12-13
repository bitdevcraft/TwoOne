using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TwoOne.Domain.Entities.Authorizations.Roles;
using TwoOne.Domain.Entities.Users;
using TwoOne.Persistence.Seeds.DefaultDbData;

namespace TwoOne.Persistence;

public class AppDbContext : IdentityDbContext<User, Role, string>
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("app");
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        builder.SeedData();
    }
}