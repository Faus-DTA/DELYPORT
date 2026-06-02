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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var asignaciones = await _asignacionService.GetAllAsignacionesAsync();
        return Ok(asignaciones);
    }

    [HttpPost("desde-solicitud/{solicitudId}")]
    public async Task<IActionResult> CrearDesdeSolicitud(int solicitudId)
    {
        try
        {
            var asignacion = await _asignacionService.CrearDesdeSolicitudAsync(solicitudId);
            return Ok(asignacion);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
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

    /// <summary>
    /// Permite a un conductor aceptar o rechazar un servicio asignado (TASK-023, TASK-024, TASK-025)
    /// </summary>
    [HttpPost("{id}/responder")]
    public async Task<IActionResult> ResponderAsignacion(int id, [FromBody] RespuestaAsignacionDto respuesta)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resultado = await _asignacionService.ResponderAsignacionAsync(id, respuesta);

        if (!resultado)
            return NotFound(new { message = $"No se pudo procesar la respuesta. Verifica que el ID {id} exista y esté en estado Pendiente." });

        var mensaje = respuesta.Aceptar ? "Servicio aceptado y actualizado a estado 'EnProceso'." : "Servicio rechazado.";
        return Ok(new { message = mensaje });
    }

    /// <summary>
    /// Actualiza el estado de un servicio y guarda en el historial (TASK-027, TASK-028, TASK-029, TASK-030, TASK-031)
    /// </summary>
    [HttpPatch("{id}/estado")]
    public async Task<ActionResult<CambioEstadoResponseDto>> ActualizarEstado(int id, [FromBody] CambioEstadoRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _asignacionService.ActualizarEstadoAsync(id, request);

        if (response == null)
            return NotFound(new { message = $"No se encontró la asignación de servicio con ID {id}" });

        return Ok(response);
    }
}
