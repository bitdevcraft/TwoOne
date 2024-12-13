using Scrutor;

using TwoOne.Application;
using TwoOne.Infrastructure;
using TwoOne.Persistence;
using TwoOne.Presentation;

namespace TwoOne.Services.App;

internal static class DependencyInjection
{
    public static IServiceCollection AddAppDiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddClassLibDependencyInjectionService(configuration);

        services.AddAssemblyService(configuration);

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