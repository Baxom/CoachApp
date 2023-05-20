using CoachApp.EFCore.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoachApp.EFCore;
public static class IHostExtentions
{
    public static IHost UseEFCore(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<CoachAppContext>().Initialize();
        return host;
    }

}
