
using Usuario.Domain.Abstractions;

namespace Usuario.Domain.Usuario;

public class UsuarioErrores
{
    public static Error YaSeEncuentraActivo = new(
        "Usuario.YaSeEncuentraActivo",
        "El usuario ya se encuentra activo por tanto no se puede volver a activar"
    );

    public static Error YaSeEncuentraInactivo = new(
        "Usuario.YaSeEncuentraInactivo",
        "El usuario ya se encuentra inactivo por tanto no se puede volver a inactivar"
    );


    public static Error NoEncontrado = new(
       "Usuario.NoEncontrado",
       "No se encontro el Usuario"
   );

}