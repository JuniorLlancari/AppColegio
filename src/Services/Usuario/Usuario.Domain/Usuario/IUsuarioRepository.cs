namespace Usuario.Domain.Usuario;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Usuario usuario);

    void Delete(Usuario id);

    Task<bool> ExisteCorreoAsync(
            CorreoElectronico correoElectronico,
            CancellationToken cancellationToken = default
    );

}