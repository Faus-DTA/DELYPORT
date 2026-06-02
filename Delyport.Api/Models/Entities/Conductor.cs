using System.ComponentModel.DataAnnotations;

namespace Delyport.Api.Models.Entities;

public class Conductor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string NombreCompleto { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [MaxLength(20)]
    public string PlacaVehiculo { get; set; } = string.Empty;
}
