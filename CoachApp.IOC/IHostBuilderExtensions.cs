using CoachApp.Serilog;
using Microsoft.Extensions.Hosting;

namespace CoachApp.IOC;
public static class IHostBuilderExtensions
{
    public static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureSerilog();
    }
}
