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

    [Required(ErrorMessage = "El tamaño es obligatorio")]
    public int Tamano { get; set; } // 0: Pequeno, 1: Mediano, 2: Grande

    [Range(1, 1000, ErrorMessage = "La cantidad debe ser al menos 1")]
    public int CantidadProductos { get; set; }
}
