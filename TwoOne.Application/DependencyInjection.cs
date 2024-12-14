using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace TwoOne.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDiServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });
        
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

        return services;
    }
}