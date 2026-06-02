using System.ComponentModel.DataAnnotations;

namespace Delyport.Api.Models.DTOs;

public class CrearSolicitudDto
{
    [Required(ErrorMessage = "El cliente es obligatorio")]
    [MaxLength(100)]
    public string Cliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El detalle de la carga es obligatorio")]
    [MaxLength(500)]
    public string DetalleCarga { get; set; } = string.Empty;

    [Range(0.1, 100000, ErrorMessage = "El peso debe ser mayor a 0")]
    public decimal PesoKg { get; set; }
}
