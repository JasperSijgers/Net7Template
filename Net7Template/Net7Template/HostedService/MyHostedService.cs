using Microsoft.Extensions.Hosting;
using Net7Template.Service;

namespace Net7Template.HostedService;

public class MyHostedService : IHostedService, IDisposable
{
    private readonly IMyService _myService;
    private Timer? _timer;

    public MyHostedService(IMyService myService)
    {
        _myService = myService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ExecuteMyServiceAction, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void ExecuteMyServiceAction(object? state)
    {
        _myService.DoAction();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}