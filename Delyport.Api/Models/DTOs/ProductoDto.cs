using System.ComponentModel.DataAnnotations;

namespace Delyport.Api.Models.DTOs;

public class ProductoDto
{
    [Required]
    public int Tamano { get; set; }

    [Range(1, 1000, ErrorMessage = "La cantidad debe ser al menos 1")]
    public int Cantidad { get; set; }
}

public class ProductoResponseDto
{
    public string Tamano { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}
