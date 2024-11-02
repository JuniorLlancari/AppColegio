using Usuario.Application.Abstractions.Messaging;
using Usuario.Application.Dtos;

namespace Usuario.Application.Usuario.Querys.ObtenerUsuarios;

public record ObtenerUsuariosQuery() : IQuery<IReadOnlyCollection<UsuarioResponse>>;

