using Delyport.Api.Models.DTOs;
using Delyport.Api.Models.Entities;

namespace Delyport.Api.Services;

public interface IAsignacionService
{
    Task<IEnumerable<AsignacionServicio>> GetAllAsignacionesAsync();
    Task<AsignacionServicio?> GetAsignacionByIdAsync(int id);
    Task<AsignacionServicio> CrearDesdeSolicitudAsync(int solicitudId);
    Task<ServicioDetalleDto?> ObtenerDetalleServicioAsync(int id);
    Task<bool> ResponderAsignacionAsync(int id, RespuestaAsignacionDto respuesta);
    Task<CambioEstadoResponseDto?> ActualizarEstadoAsync(int id, CambioEstadoRequestDto request);
}
