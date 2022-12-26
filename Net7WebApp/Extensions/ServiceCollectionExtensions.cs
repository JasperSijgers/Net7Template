using Net7WebApp.HostedService;
using Net7WebApp.Service;

namespace Net7WebApp.Extensions;

public static class ServiceCollectionExtensions
{
    private const string MyServiceSettingsConfigurationKey = "MyService";

    public static void ConfigureMyService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MyServiceSettings>(configuration, MyServiceSettingsConfigurationKey);
        services.AddSingleton<IMyService, MyService>();
    }

    public static void ConfigureMyHostedService(this IServiceCollection services)
    {
        services.AddHostedService<MyHostedService>();
    }
}