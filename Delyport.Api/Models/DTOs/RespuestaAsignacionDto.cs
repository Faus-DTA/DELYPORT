using System.ComponentModel.DataAnnotations;

namespace Delyport.Api.Models.DTOs;

public class RespuestaAsignacionDto
{
    [Required]
    public bool Aceptar { get; set; }
    
    public string? Motivo { get; set; }
    
    [Required]
    public int ConductorId { get; set; }
}
