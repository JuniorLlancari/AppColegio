using Usuario.Application.Abstractions.Messaging;
using Usuario.Application.Dtos;
using Usuario.Domain.Abstractions;
using Usuario.Domain.Usuario;

namespace Usuario.Application.Usuario.Querys.ObtenerUsuarios;

public class ObtenerUsuarioQueryHandler : IQueryHandler<ObtenerUsuarioQuery, UsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;
    public ObtenerUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    public async Task<Result<UsuarioResponse>> Handle(ObtenerUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObtenerPorIdAsync(request.UsuarioId, "Rol", cancellationToken);
        if (usuario == null)
        {
            return Result.Failure<UsuarioResponse>(UsuarioErrores.NoEncontrado);
        }

        return new UsuarioResponse(
            Id: usuario.Id,
            Nombres: usuario.NombresPersona!.Value != null ? usuario.NombresPersona.Value : "",
            NombreUsuario: usuario.NombreUsuario != null ? usuario.NombreUsuario.Value : "",
            ApellidoPaterno: usuario.ApellidoPaterno != null ? usuario.ApellidoPaterno.Value : "",
            ApellidoMaterno: usuario.ApellidoMaterno != null ? usuario.ApellidoMaterno.Value : "",
            Rol: usuario.Rol != null ? (usuario.Rol.NombreRol != null ? usuario.Rol.NombreRol.Value : "") : "",
            CorreoElectronico: usuario.CorreoElectronico != null ? usuario.CorreoElectronico.Value : "",
            Pais: usuario.Direccion != null ? (usuario.Direccion.Pais ?? "") : "",
            Departamento: usuario.Direccion != null ? (usuario.Direccion.Departamento ?? "") : "",
            Provincia: usuario.Direccion != null ? (usuario.Direccion.Provincia ?? "") : "",
            Distrito: usuario.Direccion != null ? (usuario.Direccion.Distrito ?? "") : "",
            Calle: usuario.Direccion != null ? (usuario.Direccion.Calle ?? "") : "",
            Estado: usuario.Estado.ToString(),
            FechaUltimoCambio: usuario.FechaUltimoCambio
        );

    }
}
