using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net7Template.HostedService;
using Net7Template.Service;

namespace Net7Template.Extensions;

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