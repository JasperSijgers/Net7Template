namespace Net7WebApp.Extensions;

public static class ConfigurationExtensions
{
    public static void Configure<T>(this IServiceCollection services, IConfiguration configuration, string section)
        where T : class, new()
    {
        services.Configure<T>(options => configuration.GetSection(section).Bind(options));
    }
}