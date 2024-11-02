namespace Usuario.Application.Dtos;

public class UsuarioDto
{

}
public sealed record UsuarioResponse
(
    Guid Id,
    string Nombres,
    string NombreUsuario,
    string ApellidoPaterno,
    string ApellidoMaterno,
    string Rol,
    string CorreoElectronico,
    string Pais,
    string Departamento,
    string Provincia,
    string Distrito,
    string Calle,
    string Estado,
    DateTime FechaUltimoCambio
);

public sealed record CrearUsuarioRequest
(
    string Password
   , string Rol
   , string Nombres
   , string ApellidoPaterno
   , string ApellidoMaterno
   , DateTime FechaNacimiento
   , string Pais
   , string Departamento
   , string Provincia
   , string Ciudad
   , string Distrito
   , string Calle
   , string CorreoElectronico
);