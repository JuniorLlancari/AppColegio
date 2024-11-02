using Bogus;
using Usuario.Domain.Rol;
using Usuario.Domain.Rol.ValueObjects;
using Usuario.Domain.Usuario.ValueObjects;
using UsuarioDomain = Usuario.Domain.Usuario;

namespace Usuario.Infraestructure.Extensions;
internal class InitialData
{
    public static List<Rol> ObtenerRoles()
    {
        List<Rol> roles =
        [
            Rol.Create(new NombreRol("Docente"), new Descripcion("Usuario a cargo del dictado de los cursos")),
            Rol.Create(new NombreRol("Estudiante"), new Descripcion("Usuario inscrito en los cursos a dictar")),
        ];
        return roles;
    }

    public static IEnumerable<UsuarioDomain.Usuario> ObtenerUsuarios(List<Rol> roles)
    {

        List<UsuarioDomain.Usuario> usuarios = new();

        for (int i = 0; i < 15; i++)
        {
            var fake = new Faker();

            int indexRolAleatorio = fake.Random.Int(0, roles.Count - 1);
            var maximoFechaNacimiento = fake.Date.Past(50);

            var nombreService = new NombreUsuarioService();
            var usuario = UsuarioDomain.Usuario.Create(
                new ApellidoPaterno(fake.Person.LastName),
                new ApellidoMaterno(fake.Person.LastName),
                new NombresPersona(fake.Person.FirstName),
                (Guid)((dynamic)roles[indexRolAleatorio]).Id,
                Password.Create(fake.Person.UserName),
                fake.Date.Between(maximoFechaNacimiento, DateTime.UtcNow).ToUniversalTime(),
                CorreoElectronico.Create(fake.Person.Email).Value,
                new Direccion(
                    fake.Address.Country(),
                    fake.Address.City(),
                    fake.Address.City(),
                    fake.Address.StreetName(),
                    fake.Address.StreetAddress()
                ),
                DateTime.UtcNow.ToUniversalTime(),
                nombreService
            );
            usuarios.Add(usuario);
        }
        return usuarios;
    }


}