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
}
