using CoachApp.Api.Jwt;
using CoachApp.Api.OptionsSetup;
using CoachApp.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CoachApp.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security",
        };

        var securityReq = new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        };

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(o =>
        {
            //o.AddSecurityDefinition("Bearer", securityScheme);
            //o.AddSecurityRequirement(securityReq);
        });

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication()
                .AddJwtBearer();

        //services.AddAuthorization();

        services.AddSingleton<IProvideJwt, JwtProvider>()
                .AddScoped<IAuthenticateUser, UserAuthenticator>();

        services.ConfigureOptions<JwtConfigurationSetup>()
                    .AddTransient(p => p.GetRequiredService<IOptions<JwtConfiguration>>().Value)
                    .ConfigureOptions<JwtBearerOptionsSetup>()
                    .AddTransient(p => p.GetRequiredService<IOptions<JwtBearerOptions>>().Value);

        return services;
    }

}
