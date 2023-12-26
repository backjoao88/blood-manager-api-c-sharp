using System.Reflection;
using BloodManager.Application.Abstractions.BkMediator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// Dependency injection for the application layer.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddBkMediator(this IServiceCollection services, Assembly assembly)
    {
        // Inject the mediator pattern service
        services.AddTransient<IBkMediator, BkMediator>();
        var handlers = assembly.GetTypes().Where(o => o.Name.EndsWith("Handler") && !o.IsAbstract && !o.IsInterface);
        foreach (var handler in handlers)
        {
            var interfaceType = handler.GetInterfaces().FirstOrDefault();
            if (interfaceType != null) services.AddScoped(interfaceType, handler);
        }
        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}