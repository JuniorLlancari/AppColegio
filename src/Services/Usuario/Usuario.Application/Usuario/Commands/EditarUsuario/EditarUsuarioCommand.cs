using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Application.Abstractions.Messaging;

namespace Usuario.Application.Usuario.Commands.EditarUsuario;

public record EditarUsuarioCommand(
     string Nombres
   , string ApellidoPaterno
   , string ApellidoMaterno
   , DateTime FechaNacimiento
   , string CorreoElectronico
   ) : ICommand<Guid>;


