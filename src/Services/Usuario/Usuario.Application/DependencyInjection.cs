using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Application.Abstractions.Behaviors;
using Usuario.Domain.Usuario.ValueObjects;

namespace Usuario.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient<NombreUsuarioService>();

        return services;
    }
}
