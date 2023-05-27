using CoachApp.Application.Core.Mediatr;
using CoachApp.Application.Domain.Users.Context;
using CoachApp.CQRS;
using CoachApp.CQRS.Mediatr;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.Application;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddUserContext(this IServiceCollection services)
    {
        return services.AddScoped<IUserContext, UserContext>()
                    .AddSingleton<IUserContextFactory, UserContextFactory>();
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddCQRS(new[] { typeof(FluentValidationBehavior<,>), typeof(TransactionBehavior<,>), typeof(EventPublisherBehavior<,>) });
    }
}
