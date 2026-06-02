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

    [Required(ErrorMessage = "La dirección es obligatoria")]
    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El distrito es obligatorio")]
    [MaxLength(100)]
    public string Distrito { get; set; } = string.Empty;

    [Required]
    [MinLength(1, ErrorMessage = "Debe enviar al menos un producto en la cotización.")]
    public List<ProductoDto> Productos { get; set; } = new List<ProductoDto>();
}
