using Microsoft.Extensions.Hosting;
using Serilog;

namespace CoachApp.Serilog;

public static class SerilogExtensions
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((hostContext, services, configuration) =>
        {
            configuration
                .WriteTo.File(@"C:\Logs\serilog-file.txt")
                .WriteTo.Console();
        });
    }
}