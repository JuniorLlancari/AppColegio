
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuarioDomain = Usuario.Domain.Usuario;

namespace Usuario.Infraestructure.Configurations;

public class UsuarioConfigurations : IEntityTypeConfiguration<UsuarioDomain.Usuario>
{
    public void Configure(EntityTypeBuilder<UsuarioDomain.Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(usuario => usuario.Direccion);


        builder.Property(usuario => usuario.NombreUsuario)
            .HasMaxLength(30)
            .HasConversion(nombre => nombre!.Value, value => new UsuarioDomain.NombreUsuario(value));

        builder.Property(usuario => usuario.NombresPersona)
            .HasMaxLength(50)
            .HasConversion(nombre => nombre!.Value, value => new UsuarioDomain.NombresPersona(value));

        builder.Property(usuario => usuario.ApellidoPaterno)
            .HasMaxLength(50)
            .HasConversion(nombre => nombre!.Value, value => new UsuarioDomain.ApellidoPaterno(value));

        builder.Property(usuario => usuario.ApellidoMaterno)
            .HasMaxLength(50)
            .HasConversion(nombre => nombre!.Value, value => new UsuarioDomain.ApellidoMaterno(value));

        builder.Property(usuario => usuario.CorreoElectronico)
            .HasMaxLength(150)
            .HasConversion(nombre => nombre!.Value, value => UsuarioDomain.CorreoElectronico.Create(value).Value);

        builder.Property(usuario => usuario.Password)
            .HasMaxLength(150)
            .HasConversion(nombre => nombre!.Value, value => UsuarioDomain.Password.Create(value));

        builder.Property(usuario => usuario.FechaNacimiento);

        builder.Property(usuario => usuario.Estado)
            .HasConversion(
                estado => estado.ToString(),
                estado => (UsuarioDomain.UsuarioEstado)Enum.Parse(typeof(UsuarioDomain.UsuarioEstado), estado)
            );

        builder.Property(usuario => usuario.FechaUltimoCambio);

        builder.HasOne(usuario => usuario.Rol)
        .WithMany()
        .HasForeignKey(usuario => usuario.RolId)
        .IsRequired();

        builder.Property<uint>("Version").IsRowVersion();
    }
}