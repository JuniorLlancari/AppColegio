using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Application.Abstractions.Data;
using Usuario.Application.Time;
using Usuario.Domain.Abstractions;
using Usuario.Domain.Rol;
using Usuario.Domain.Usuario;
using Usuario.Infraestructure.Data;
using Usuario.Infraestructure.Repositories;
using Usuario.Infraestructure.Time;

namespace Usuario.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        var connectionString = configuration.GetConnectionString("Database")
        ?? throw new ArgumentNullException(nameof(configuration));
        var urlRabbit = configuration["UrlRabbit"];

        services.AddDbContext<ApplicationDbContext>(
        options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));



        return services;
    }
}
