using CoachApp.Application.Domain.Users.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.Application;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddUserContext(this IServiceCollection services)
    {

        return services.AddScoped<IUserContext, UserContext>()
                    .AddSingleton<IUserContextFactory, UserContextFactory>();
    }
}
