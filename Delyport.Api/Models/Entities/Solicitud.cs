using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.Entities;

public class Solicitud
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Cliente { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string DetalleCarga { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Distrito { get; set; } = string.Empty;

    public TamanoProducto Tamano { get; set; } = TamanoProducto.Pequeno;

    public int CantidadProductos { get; set; } = 1;

    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioTotal { get; set; }

    public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Registrado;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
