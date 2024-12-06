using Microsoft.Extensions.DependencyInjection;

namespace TwoOne.Persistence;

internal static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDiServices(this IServiceCollection services)
    {
        return services;
    }
}
