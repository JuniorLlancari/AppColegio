using System.Linq.Expressions;
using Usuario.Domain.Usuario.ValueObjects;

namespace Usuario.Domain.Usuario;

public interface IUsuarioRepository
{
    Task<Usuario?> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Usuario?> ObtenerPorIdAsync(Guid id, string relaciones, CancellationToken cancellationToken = default);

    Task AgregarAsync(Usuario entidad);

    Task<ICollection<Usuario>> ListarAsync(
        Expression<Func<Usuario, bool>> predicado, bool tracking = false, string? relaciones = null);

    Task<bool> ExisteCorreoAsync(
            CorreoElectronico correoElectronico,
            CancellationToken cancellationToken = default
    );

}