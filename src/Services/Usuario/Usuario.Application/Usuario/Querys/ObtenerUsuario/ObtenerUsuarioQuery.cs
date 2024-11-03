using Usuario.Application.Abstractions.Messaging;
using Usuario.Application.Dtos;

namespace Usuario.Application.Usuario.Querys.ObtenerUsuarios;

public record ObtenerUsuarioQuery(Guid UsuarioId) : IQuery<UsuarioResponse>;

