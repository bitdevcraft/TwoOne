using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TwoOne.Domain.Entities.Authorizations.Roles;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Persistence;

public static class DependencyInjection
{
    /// <summary>
    /// Persistence Dependency Injection Service
    /// </summary>
    /// <param name="services">self</param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersistenceDiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.DatabaseService(configuration);
        return services;
    }

    /// <summary>
    /// Connect the DbContext 
    /// </summary>
    /// <param name="services">self</param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection DatabaseService(this IServiceCollection services, IConfiguration configuration)
    {
        // Set up the connection to the Database
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        
        return services;
    }
}
