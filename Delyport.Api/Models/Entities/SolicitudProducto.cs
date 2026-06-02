using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.Entities;

public class SolicitudProducto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int SolicitudId { get; set; }

    public TamanoProducto Tamano { get; set; } = TamanoProducto.Pequeno;

    public int Cantidad { get; set; } = 1;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }

    // Relación
    [ForeignKey("SolicitudId")]
    public Solicitud? Solicitud { get; set; }
}
