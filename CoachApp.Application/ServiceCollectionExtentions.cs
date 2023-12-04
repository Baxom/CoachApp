using CoachApp.Application.Core.Encrypting;
using CoachApp.Application.Core.Mediatr;
using CoachApp.Application.Core.Security;
using CoachApp.Application.Domain.Users.Context;
using CoachApp.CQRS;
using CoachApp.DDD;
using CoachApp.DDD.Mediatr;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.Application;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddUserContext(this IServiceCollection services)
    {
        return services
                    .AddScoped<IUserContextProvider, UserContextProvider>()
                    .AddScoped(p => p.GetRequiredService<IUserContextProvider>().UserContext)
                    .AddSingleton<IUserContextFactory, ScopedUserContextFactory>();
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddSecurity()
            .AddCQRS(new[] { typeof(FluentValidationBehavior<,>), typeof(TransactionBehavior<,>), typeof(EventPublisherBehavior<,>) });
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        return services
            .AddSingleton<IEncrypt, CryptographyEncryptor>()
            .AddSingleton<IManagePassword, Sha512PasswordManager>();
    }
}
