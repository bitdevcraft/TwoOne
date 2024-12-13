using Microsoft.Extensions.DependencyInjection;

namespace TwoOne.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationDiServices(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddApplicationPart(TwoOne.Presentation.AssemblyReference.Assembly);
        return services;
    }
}
