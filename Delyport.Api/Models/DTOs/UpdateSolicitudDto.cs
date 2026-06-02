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

    [Required(ErrorMessage = "La dirección es obligatoria")]
    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El distrito es obligatorio")]
    [MaxLength(100)]
    public string Distrito { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tamaño es obligatorio")]
    public int Tamano { get; set; } 

    [Range(1, 1000, ErrorMessage = "La cantidad debe ser al menos 1")]
    public int CantidadProductos { get; set; }
}
