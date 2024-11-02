using MediatR;
using Microsoft.AspNetCore.Mvc;
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

}
