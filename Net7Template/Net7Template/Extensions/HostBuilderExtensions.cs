using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net7Template.Extensions;

public static class HostBuilderExtensions
{
    public static void ConfigureBuilder(this IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.Sources.Clear();

            config.SetBasePath(context.HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        });

        builder.ConfigureServices((context, services) =>
        {
            services.AddOptions();
            ConfigureServices(services, context.Configuration);
        });
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMyService(configuration);
        services.ConfigureMyHostedService();
    }
}