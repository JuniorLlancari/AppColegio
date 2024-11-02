namespace Usuario.Domain.Usuario.ValueObjects;

public record Direccion
(
    string? Pais,
    string? Departamento,
    string? Provincia,
    string? Distrito,
    string? Calle
);