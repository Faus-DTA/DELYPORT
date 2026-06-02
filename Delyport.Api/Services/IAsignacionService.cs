using Delyport.Api.Models.DTOs;

namespace Delyport.Api.Services;

public interface IAsignacionService
{
    Task<ServicioDetalleDto?> ObtenerDetalleServicioAsync(int id);
    Task<bool> ResponderAsignacionAsync(int id, RespuestaAsignacionDto respuesta);
}
