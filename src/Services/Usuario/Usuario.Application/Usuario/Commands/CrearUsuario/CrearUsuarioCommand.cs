using Usuario.Application.Abstractions.Messaging;

namespace Usuario.Application.Usuario.CrearUsuario;

public record CrearUsuarioCommand(
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
   ) : ICommand<Guid>;


