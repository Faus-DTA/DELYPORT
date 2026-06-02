namespace Delyport.Api.Models.DTOs;

public class AsignacionListDto
{
    public int Id { get; set; }
    public string CodigoServicio { get; set; } = string.Empty;
    public string Origen { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public int ConductorId { get; set; }
    public string ConductorNombre { get; set; } = string.Empty;
    public decimal Tarifa { get; set; }
    public int Estado { get; set; }
}
