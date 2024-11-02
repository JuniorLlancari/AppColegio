using Dapper;
using Usuario.Application.Abstractions.Messaging;
using Usuario.Application.Dtos;
using Usuario.Domain.Abstractions;
using Usuario.Domain.Usuario;
using Usuario.Domain.Usuario.ValueObjects;

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
        var usuarios = await _usuarioRepository.ListAsync(cancellationToken);

        return usuarios.Select(usuario => new UsuarioResponse(
            Id: usuario.Id,
            Nombres: usuario.NombresPersona.Value,
            NombreUsuario: usuario.NombreUsuario.Value,
            ApellidoPaterno: usuario.ApellidoPaterno.Value,
            ApellidoMaterno: usuario.ApellidoMaterno.Value,
            Rol: "",
            CorreoElectronico: usuario.CorreoElectronico != null ? usuario.CorreoElectronico.Value : "",
            Pais: usuario.Direccion.Pais,
            Departamento: usuario.Direccion.Departamento,
            Provincia: usuario.Direccion.Provincia,
            Distrito: usuario.Direccion.Distrito,
            Calle: usuario.Direccion.Calle,
            Estado: usuario.ApellidoPaterno.Value,
            FechaUltimoCambio: usuario.FechaUltimoCambio
         )).AsList().AsReadOnly();


    }
}
