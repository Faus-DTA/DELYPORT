using System.ComponentModel.DataAnnotations;

namespace Delyport.Api.Models.DTOs;

public class UpdateSolicitudDto
{
    [Required(ErrorMessage = "El cliente es obligatorio")]
    [MaxLength(100, ErrorMessage = "El nombre del cliente no puede exceder los 100 caracteres")]
    public string Cliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El detalle de la carga es obligatorio")]
    [MaxLength(500, ErrorMessage = "El detalle no puede exceder los 500 caracteres")]
    public string DetalleCarga { get; set; } = string.Empty;

    [Range(0.1, 100000, ErrorMessage = "El peso debe ser mayor a 0")]
    public decimal PesoKg { get; set; }
}
