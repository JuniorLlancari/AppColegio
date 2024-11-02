using MediatR;
using Microsoft.AspNetCore.Mvc;
using Usuario.Application.Dtos;
using Usuario.Application.Usuario.CrearUsuario;
using Usuario.Application.Usuario.Querys.ObtenerUsuarios;

namespace Usuario.Api.Controllers.Usuario;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ISender _sender;

    public UsuarioController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerUsuarios(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new ObtenerUsuariosQuery(), cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CrearUsuario(CrearUsuarioRequest request, CancellationToken cancellationToken)
    {
        var command = new CrearUsuarioCommand
        (
            request.Password,
            request.Rol,
            request.Nombres,
            request.ApellidoPaterno,
            request.ApellidoMaterno,
            request.FechaNacimiento,
            request.Pais,
            request.Departamento,
            request.Provincia,
            request.Ciudad,
            request.Distrito,
            request.Calle,
            request.CorreoElectronico
        );


        var resultado = await _sender.Send(command, cancellationToken);

        if (resultado.IsSuccess)
        {
            return Ok(resultado);
        }
        return BadRequest(resultado.Error);
    }
}
