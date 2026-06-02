using Delyport.Api.Models.DTOs;
using Delyport.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Delyport.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsignacionesController : ControllerBase
{
    private readonly IAsignacionService _asignacionService;

    public AsignacionesController(IAsignacionService asignacionService)
    {
        _asignacionService = asignacionService;
    }

    /// <summary>
    /// Obtiene el detalle de un servicio asignado por su ID (TASK-022)
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ServicioDetalleDto>> GetDetalle(int id)
    {
        var detalle = await _asignacionService.ObtenerDetalleServicioAsync(id);

        if (detalle == null)
            return NotFound(new { message = $"No se encontró la asignación de servicio con ID {id}" });

        return Ok(detalle);
    }
}
