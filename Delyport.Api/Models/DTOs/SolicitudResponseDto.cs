using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.DTOs;

public class SolicitudResponseDto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string DetalleCarga { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Distrito { get; set; } = string.Empty;
    public string TamanoProducto { get; set; } = string.Empty;
    public int CantidadProductos { get; set; }
    public decimal PrecioTotal { get; set; }
    public EstadoSolicitud Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
}
