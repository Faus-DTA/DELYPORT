using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.Entities;

public class AsignacionServicio
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string CodigoServicio { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Origen { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Destino { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Tarifa { get; set; }

    public EstadoServicio Estado { get; set; } = EstadoServicio.Pendiente;

    public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;

    // Conductor asignado (podría ser nulo inicialmente)
    public int? ConductorId { get; set; }

    // Propiedad de navegación hacia el historial
    public ICollection<HistorialEstado> HistorialEstados { get; set; } = new List<HistorialEstado>();
}
