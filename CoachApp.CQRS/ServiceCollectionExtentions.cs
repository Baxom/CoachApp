using System.Reflection;
using CoachApp.DDD.Mediatr;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.DDD;
public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddCQRS(this IServiceCollection services, Type[] mediatrBehaviours)
    {
        return services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(GetAssemblies());
            foreach (var mediatrBehaviour in mediatrBehaviours)
            {
                cfg.AddOpenBehavior(mediatrBehaviour);
            }
        });
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        foreach (var assembly in GetAssemblies())
            services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Scoped);

        services.AddSingleton(typeof(IBuildValidationResult<,>), typeof(ValidationResultBuilder<,>));

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
