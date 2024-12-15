using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using Scrutor;

using TwoOne.Application;
using TwoOne.Domain.Entities.Authorizations.Roles;
using TwoOne.Domain.Entities.Users;
using TwoOne.Infrastructure;
using TwoOne.Persistence;
using TwoOne.Presentation;

namespace TwoOne.Services.App;

internal static class DependencyInjection
{
    public static IServiceCollection AddAppDiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityService(configuration);

        services.AddClassLibDependencyInjectionService(configuration);

        services.AddAssemblyService(configuration);

        return services;
    }
    
    
    /// <summary>
    /// Set up the User and Role
    /// </summary>
    /// <param name="services">self</param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection AddIdentityService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        
        services.AddSingleton<TimeProvider>(TimeProvider.System);
        services
            .AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();

        return services;
    }

    /// <summary>
    /// Injecting the Class Libraries' Dependency Injection
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection AddClassLibDependencyInjectionService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddPersistenceDiServices(configuration)
            .AddApplicationDiServices()
            .AddInfrastructureDiServices()
            .AddPresentationDiServices();
        return services;
    }


    /// <summary>
    /// Adding the Assembly References of the Class Libraries
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection AddAssemblyService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Scan(selector =>
            selector
                .FromAssemblies(
                    TwoOne.Infrastructure.AssemblyReference.Assembly,
                    TwoOne.Persistence.AssemblyReference.Assembly
                )
                .AddClasses(false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );
        return services;
    }
}