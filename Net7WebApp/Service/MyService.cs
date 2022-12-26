using Microsoft.Extensions.Options;

namespace Net7WebApp.Service;

public class MyService : IMyService
{
    private readonly MyServiceSettings _settings;

    public MyService(IOptions<MyServiceSettings> settings)
    {
        _settings = settings.Value;
    }

    public void DoAction()
    {
        Console.WriteLine($"String from settings: {_settings.String}\n" +
                          $"Number from settings: {_settings.Number}");
    }
}