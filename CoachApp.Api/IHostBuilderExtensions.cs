using CoachApp.IOC;

namespace CoachApp.Api;

internal static class IHostBuilderExtensions
{
    public static IHostBuilder ConfigureHostBuilder(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureLogging();
    }
}