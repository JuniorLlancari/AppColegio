using Usuario.Domain.Abstractions;

namespace Usuario.Domain.Usuario.Events;

public sealed record UserCreateDomainEvent(Guid IdUsuario) : IDomainEvent;