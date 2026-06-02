using Delyport.Api.Models.DTOs;
using Delyport.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Delyport.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitudesController : ControllerBase
{
    private readonly ISolicitudService _solicitudService;

    public SolicitudesController(ISolicitudService solicitudService)
    {
        _solicitudService = solicitudService;
    }

    /// <summary>
    /// Consulta las solicitudes en estado 'Registrado' (TASK-033)
    /// </summary>
    [HttpGet("registradas")]
    public async Task<ActionResult<IEnumerable<SolicitudResponseDto>>> GetRegistradas()
    {
        var registradas = await _solicitudService.GetSolicitudesRegistradasAsync();
        return Ok(registradas);
    }

    /// <summary>
    /// Actualiza una solicitud si está en estado 'Registrado' (TASK-036)
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<SolicitudResponseDto>> UpdateSolicitud(int id, [FromBody] UpdateSolicitudDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var actualizada = await _solicitudService.ActualizarSolicitudAsync(id, request);
            
            if (actualizada == null)
                return NotFound(new { message = $"No se encontró la solicitud con ID {id}" });

            return Ok(actualizada); // Sincroniza cambios en vista (TASK-038)
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
