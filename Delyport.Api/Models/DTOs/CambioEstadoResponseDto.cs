using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.DTOs;

public class CambioEstadoResponseDto
{
    public int IdServicio { get; set; }
    public EstadoServicio EstadoActual { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public string Mensaje { get; set; } = string.Empty;
}
