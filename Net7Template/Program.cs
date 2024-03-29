﻿using Microsoft.Extensions.Hosting;
using Net7Template.Extensions;
using Serilog;

var serilog = new LoggerConfiguration()
    .WriteTo.File("logs/program.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureLogging(log =>
{
    log.AddSerilog(serilog);
});

builder.ConfigureBuilder();

var host = builder.Build();
await host.RunAsync();