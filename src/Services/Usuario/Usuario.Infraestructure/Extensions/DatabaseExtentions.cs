using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Domain.Rol;
using UsuarioDomain = Usuario.Domain.Usuario;

namespace Usuario.Infraestructure.Extensions;
public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedRolAsync(context);
        await SeedUsuarioAsync(context);
    }

    private static async Task SeedRolAsync(ApplicationDbContext context)
    {
        if (!await context.Set<Rol>().AnyAsync())
        {
            await context.Set<Rol>().AddRangeAsync(InitialData.ObtenerRoles());
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedUsuarioAsync(ApplicationDbContext context)
    {
        if (!await context.Set<UsuarioDomain.Usuario>().AnyAsync())
        {
            var roles = await context.Set<Rol>().ToListAsync();
            await context.Set<UsuarioDomain.Usuario>().AddRangeAsync(InitialData.ObtenerUsuarios(roles));
            await context.SaveChangesAsync();
        }
    }


}