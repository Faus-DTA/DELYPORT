using Delyport.Api.Data;
using Delyport.Api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Delyport.Api.Services;

public class AsignacionService : IAsignacionService
{
    private readonly ApplicationDbContext _context;

    public AsignacionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServicioDetalleDto?> ObtenerDetalleServicioAsync(int id)
    {
        var servicio = await _context.AsignacionesServicio
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        if (servicio == null)
            return null;

        // Mapeo manual (se podría usar AutoMapper en el futuro)
        return new ServicioDetalleDto
        {
            Id = servicio.Id,
            CodigoServicio = servicio.CodigoServicio,
            Descripcion = servicio.Descripcion,
            Origen = servicio.Origen,
            Destino = servicio.Destino,
            Tarifa = servicio.Tarifa,
            Estado = servicio.Estado,
            FechaAsignacion = servicio.FechaAsignacion
        };
    }
}
