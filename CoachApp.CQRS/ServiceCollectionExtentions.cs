using System.Reflection;
using CoachApp.CQRS.Mediatr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.CQRS;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddCQRS(this IServiceCollection services)
    {
        return services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(GetAssemblies());
            
        })
        .AddSingleton(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        foreach (var assembly in GetAssemblies())
            services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Singleton);

        return services;
        
    }

    private static Assembly[] GetAssemblies()
    {
        var returnAssemblies = new List<Assembly>();
        var loadedAssemblies = new HashSet<string>();
        var assembliesToCheck = new Queue<Assembly>();

        assembliesToCheck.Enqueue(Assembly.GetEntryAssembly()!);

        while (assembliesToCheck.Any())
        {
            var assemblyToCheck = assembliesToCheck.Dequeue();

            foreach (var reference in assemblyToCheck.GetReferencedAssemblies())
            {
                if (!loadedAssemblies.Contains(reference.FullName))
                {
                    var assembly = Assembly.Load(reference);
                    assembliesToCheck.Enqueue(assembly);
                    loadedAssemblies.Add(reference.FullName);
                    returnAssemblies.Add(assembly);
                }
            }
        }

        return returnAssemblies.ToArray();
    }
}
