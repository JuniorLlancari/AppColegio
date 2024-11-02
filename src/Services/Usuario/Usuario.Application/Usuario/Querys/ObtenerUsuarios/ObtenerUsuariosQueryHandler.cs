using Dapper;
using Usuario.Application.Abstractions.Messaging;
using Usuario.Application.Dtos;
using Usuario.Domain.Abstractions;
using Usuario.Domain.Usuario;

namespace Usuario.Application.Usuario.Querys.ObtenerUsuarios;

public class ObtenerUsuariosQueryHandler : IQueryHandler<ObtenerUsuariosQuery, IReadOnlyCollection<UsuarioResponse>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    public ObtenerUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    public async Task<Result<IReadOnlyCollection<UsuarioResponse>>> Handle(ObtenerUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioRepository.ListarAsync(p => p.Estado == UsuarioEstado.Activo, false, "Rol");

        return usuarios.Select(usuario => new UsuarioResponse(
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
        )).AsList().AsReadOnly();
    }
}
