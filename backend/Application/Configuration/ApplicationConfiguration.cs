using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationConfiguration
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddSingleton<IGameCoordinator, GameCoordinator>();
        services.AddSingleton<IGameBridgeFactory, GameBridgeFactory>();
    }

}