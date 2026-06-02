using Delyport.Api.Models.DTOs;

namespace Delyport.Api.Services;

public interface ISolicitudService
{
    Task<IEnumerable<SolicitudResponseDto>> GetSolicitudesRegistradasAsync();
    Task<SolicitudResponseDto?> ActualizarSolicitudAsync(int id, UpdateSolicitudDto dto);
    Task<SolicitudResponseDto> CrearSolicitudAsync(CrearSolicitudDto dto);
}
