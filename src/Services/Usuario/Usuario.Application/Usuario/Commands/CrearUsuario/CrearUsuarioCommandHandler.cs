using Usuario.Application.Abstractions.Messaging;
using Usuario.Application.Time;
using Usuario.Domain.Abstractions;
using Usuario.Domain.Rol;
using Usuario.Domain.Usuario;
using Usuario.Domain.Usuario.ValueObjects;
using UsuarioDomain = Usuario.Domain.Usuario;

namespace Usuario.Application.Usuario.CrearUsuario;

public class CrearUsuarioCommandHandler : ICommandHandler<CrearUsuarioCommand, Guid>
{
    private readonly IRolRepository _rolRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly NombreUsuarioService _nombreUsuarioService;

    public CrearUsuarioCommandHandler(IRolRepository rolRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, NombreUsuarioService nombreUsuarioService)
    {
        _rolRepository = rolRepository;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
        _nombreUsuarioService = nombreUsuarioService;
    }

    public async Task<Result<Guid>> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {

        var rol = await _rolRepository.GetByNameAsync(request.Rol, cancellationToken);

        var usuario = UsuarioDomain.Usuario.Create(
        new ApellidoPaterno(request.ApellidoPaterno),
        new ApellidoMaterno(request.ApellidoMaterno),
        new NombresPersona(request.Nombres),
            rol.Id,
        Password.Create(request.Password),
        request.FechaNacimiento.ToUniversalTime(),
        CorreoElectronico.Create(request.CorreoElectronico).Value,
        new Direccion(
            request.Pais,
            request.Departamento,
            request.Provincia,
            request.Distrito,
            request.Calle
        ),
            _dateTimeProvider.CurrentTime.ToUniversalTime(),
        _nombreUsuarioService);

        throw new NotImplementedException();
    }
}
