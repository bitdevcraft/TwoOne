using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using TwoOne.Infrastructure.Security.Jwt;

namespace TwoOne.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDiServices(this IServiceCollection services)
    {
        services.AddAuthenticationService();
        return services;
    }

    /// <summary>
    /// Sets the Authentication Service
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddAuthenticationService(this IServiceCollection services)
    {
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer();
        
        services.AddAuthorization();
        
        return services;
    }
}