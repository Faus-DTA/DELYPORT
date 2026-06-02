using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.Entities;

public class HistorialEstado
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int AsignacionServicioId { get; set; }

    [Required]
    public EstadoServicio EstadoAnterior { get; set; }

    [Required]
    public EstadoServicio EstadoNuevo { get; set; }

    public DateTime FechaCambio { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string? Observacion { get; set; }

    [ForeignKey(nameof(AsignacionServicioId))]
    public AsignacionServicio AsignacionServicio { get; set; } = null!;
}
