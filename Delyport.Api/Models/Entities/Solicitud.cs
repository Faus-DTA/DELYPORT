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

    [Column(TypeName = "decimal(18,2)")]
    public decimal PesoKg { get; set; }

    public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Registrado;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
