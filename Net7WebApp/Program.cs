using Net7WebApp.Extensions;
using Serilog;

var serilog = new LoggerConfiguration()
    .WriteTo.File("logs/program.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddSerilog(serilog);

builder.ConfigureBuilder();

var host = builder.Build();
await host.RunAsync();