using System.ComponentModel.DataAnnotations;
using Delyport.Api.Models.Enums;

namespace Delyport.Api.Models.DTOs;

public class CambioEstadoRequestDto
{
    [Required(ErrorMessage = "El nuevo estado es obligatorio")]
    public EstadoServicio EstadoNuevo { get; set; }

    [MaxLength(200, ErrorMessage = "La observación no puede superar los 200 caracteres")]
    public string? Observacion { get; set; }
}
