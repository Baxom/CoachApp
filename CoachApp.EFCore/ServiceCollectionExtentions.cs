using CoachApp.Application.Core.Repositories;
using CoachApp.EFCore.Core.UnitOfWork;
using CoachApp.EFCore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.EFCore;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>))
            .AddScoped<IUnitOfWork, UnitOfWork>();


        return services.AddDbContextFactory<CoachAppContext>(options => options.UseSqlServer(configuration.GetValue<string>("SqlServer:ConnectionString")));
    }

}
