using System.Linq.Expressions;

namespace Usuario.Domain.Rol;

public interface IRolRepository
{
    Task<Rol?> GetByNameAsync(string rol, CancellationToken cancellationToken = default);

    Task<ICollection<Rol>> ListarAsync(
        Expression<Func<Rol, bool>> predicado, bool tracking = false, string? relaciones = null);

}