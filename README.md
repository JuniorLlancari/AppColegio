# AppColegio

AppColegio es una solución de arquitectura de microservicios utilizando .NET, organizada en capas (Domain, Application, Infrastructure, y API) para ofrecer modularidad y extensibilidad en el desarrollo de software.

## Requisitos Previos

1. **Instalar .NET SDK** versión 8.0.101.
2. **Instalar dotnet-ef** para migraciones de Entity Framework Core.
3. **Docker** (opcional) si deseas ejecutar contenedores para bases de datos o servicios de soporte.

## Configuración Inicial

1. **Configurar la versión global de .NET SDK | dotnet-ef**:
```bash
    dotnet new globaljson --sdk-version 8.0.101 --force
    dotnet tool install --global dotnet-ef --version 8.0.8
```

## Crear la Solución y Estructura de Proyectos

1. **Crear solución principal**:
    ```bash
    dotnet new sln -n AppColegio --output .\src
    ```

2. **Crear proyectos**:
    ```bash
    dotnet new classlib -o .\src\Services\Usuario\Usuario.Domain         
    dotnet new classlib -o .\src\Services\Usuario\Usuario.Application  
    dotnet new classlib -o .\src\Services\Usuario\Usuario.Infraestructure 
    dotnet new webapi -o .\src\Services\Usuario\Usuario.Api --name Usuario.Api 
    ```

3. **Agregar proyectos a la solución**:
```bash
    dotnet sln add .\src\Services\Usuario\Usuario.Domain\Usuario.Domain.csproj 
    dotnet sln add .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj
    dotnet sln add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj
    dotnet sln add .\src\Services\Usuario\Usuario.Api\Usuario.Api.csproj
```

## Configuración de Referencias entre Proyectos

```bash
    dotnet add .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj reference .\src\Services\Usuario\Usuario.Domain\Usuario.Domain.csproj
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj reference .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj
    dotnet add .\src\Services\Usuario\Usuario.Api\Usuario.Api.csproj reference .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj
    dotnet add .\src\Services\Usuario\Usuario.Api\Usuario.Api.csproj reference .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj
```

## Configuración de Nuggets de Proyectos

# Usuario.Api (API)
```bash
    dotnet add .\src\Services\Usuario\Usuario.Api\Usuario.Api.csproj package Bogus --version 35.5.1
    dotnet add .\src\Services\Usuario\Usuario.Api\Usuario.Api.csproj package Microsoft.EntityFrameworkCore.Design --version 8.0.6
    dotnet add .\src\Services\Usuario\Usuario.Api\Usuario.Api.csproj package Microsoft.EntityFrameworkCore.Tools --version 8.0.6
```
# Usuario.Application (Capa de Aplicación)
```bash
    dotnet add .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj package MediatR --version 12.2.0  
    dotnet add .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj package Dapper --version 2.1.35
    dotnet add .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj package FluentValidation.DependencyInjectionExtensions --version 11.9.2
    dotnet add .\src\Services\Usuario\Usuario.Application\Usuario.Application.csproj package Microsoft.Extensions.Logging.Abstractions --version 8.0.1
```
# Usuario.Domain (Capa de Dominio)
```bash
    dotnet add .\src\Services\Usuario\Usuario.Domain\Usuario.Domain.csproj package MediatR.Contracts --version 2.0.1
```
# Usuario.Infrastructure (Capa de Infraestructura)
```bash
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package EFCore.NamingConventions --version 8.0.3
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package Microsoft.EntityFrameworkCore --version 8.0.6
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.4
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.7
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package System.IdentityModel.Tokens.Jwt --version 7.6.3
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package Microsoft.Extensions.Configuration.Abstractions --version 8.0.0
    dotnet add .\src\Services\Usuario\Usuario.Infraestructure\Usuario.Infraestructure.csproj package RabbitMQ.Client --version 6.2.1
```

















