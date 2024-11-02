using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Usuario.ValueObjects;
using Usuario.Domain.Usuario;
using UsuarioDomain = Usuario.Domain.Usuario;

namespace Usuario.Infraestructure.Repositories;

internal sealed class UsuarioRepository : Repository<UsuarioDomain.Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExisteCorreoAsync(
    CorreoElectronico correoElectronico,
    CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<UsuarioDomain.Usuario>()
        .AnyAsync(usuario => ((string)usuario.CorreoElectronico!) == correoElectronico.Value, cancellationToken);
    }


}
