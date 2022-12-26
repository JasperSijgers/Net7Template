namespace Net7WebApp.Extensions;

public static class HostBuilderExtensions
{
    public static void ConfigureBuilder(this HostApplicationBuilder builder)
    {
        builder.Configuration.Sources.Clear();
        builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        builder.Services.AddOptions();
        ConfigureServices(builder.Services, builder.Configuration);
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMyService(configuration);
        services.ConfigureMyHostedService();
    }
}