using Usuario.Domain.Abstractions;

namespace Usuario.Domain.Rol;

public static class RolErrores
{

    public static Error NoEncontrado = new
   (
       "Rol.NoEncontrado",
       "No se encontro el rol"
   );
}