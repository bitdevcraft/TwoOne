using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TwoOne.Domain.Entities.Authorizations.Roles;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Persistence.Seeds.DefaultDbData;

public static class DefaultDbData
{
    public static ModelBuilder SeedData(this ModelBuilder builder)
    {
        builder.Entity<Role>().HasData(
            new Role
            {
                Id = "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                Name = "SystemAdministrator",
                NormalizedName = "SYSTEMADMINISTRATOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Id = "530b21d4-4dd9-4749-9444-ee1384d37d38",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Id = "c79c336b-5210-411e-b8c5-f6f210d06204",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        );

        User sysadmin = new User()  
        {  
            Id = "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",  
            UserName = "SysAdmin",  
            NormalizedUserName = "SysAdmin".ToUpperInvariant(),
            Email = "sysadmin@localhost.com",  
            NormalizedEmail = "sysadmin@localhost.com".ToUpperInvariant(),
            LockoutEnabled = false,  
            RoleId = "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
            LastName = "System Admin",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };  
        
        User admin = new User()  
        {  
            Id = "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",  
            UserName = "DemoAdmin",  
            NormalizedUserName = "DemoAdmin".ToUpperInvariant(),
            Email = "admin@localhost.com",  
            NormalizedEmail = "admin@localhost.com".ToUpperInvariant(),
            LockoutEnabled = false,  
            RoleId = "530b21d4-4dd9-4749-9444-ee1384d37d38",
            LastName = "Admin",
            ConcurrencyStamp = Guid.NewGuid().ToString()

        };  
        
        User user = new User()  
        {  
            Id = "a901fdf4-edcb-4b6d-9a65-40df5b062f24",  
            UserName = "DemoUser",  
            NormalizedUserName = "DemoUser".ToUpperInvariant(),
            Email = "user@localhost.com",  
            NormalizedEmail = "user@localhost.com".ToUpperInvariant(),
            LockoutEnabled = false,  
            RoleId = "c79c336b-5210-411e-b8c5-f6f210d06204",
            LastName = "User",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };  
  
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();  
        passwordHasher.HashPassword(sysadmin, "Administrator1!"); 
        passwordHasher.HashPassword(admin, "Administrator1!"); 
        passwordHasher.HashPassword(user, "Administrator1!"); 
        
        builder.Entity<User>().HasData([sysadmin,admin,user]);
        return builder;
    }
}