using Delyport.Api.Data;
using Delyport.Api.Models.DTOs;
using Delyport.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Delyport.Api.Services;

public class SolicitudService : ISolicitudService
{
    private readonly ApplicationDbContext _context;

    public SolicitudService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SolicitudResponseDto>> GetSolicitudesRegistradasAsync()
    {
        return await _context.Solicitudes
            .Where(s => s.Estado == EstadoSolicitud.Registrado)
            .Select(s => new SolicitudResponseDto
            {
                Id = s.Id,
                Codigo = s.Codigo,
                Cliente = s.Cliente,
                DetalleCarga = s.DetalleCarga,
                PesoKg = s.PesoKg,
                Estado = s.Estado,
                FechaCreacion = s.FechaCreacion
            })
            .ToListAsync();
    }

    public async Task<SolicitudResponseDto?> ActualizarSolicitudAsync(int id, UpdateSolicitudDto dto)
    {
        var solicitud = await _context.Solicitudes.FindAsync(id);

        if (solicitud == null)
            return null; // No existe

        // Validar que solo se puedan modificar las solicitudes en estado "Registrado" (TASK-035)
        if (solicitud.Estado != EstadoSolicitud.Registrado)
            throw new InvalidOperationException("Solo se pueden modificar las solicitudes que se encuentran en estado Registrado.");

        // Aplicar cambios
        solicitud.Cliente = dto.Cliente;
        solicitud.DetalleCarga = dto.DetalleCarga;
        solicitud.PesoKg = dto.PesoKg;

        _context.Solicitudes.Update(solicitud);
        await _context.SaveChangesAsync(); // Persistir (TASK-037)

        return new SolicitudResponseDto
        {
            Id = solicitud.Id,
            Codigo = solicitud.Codigo,
            Cliente = solicitud.Cliente,
            DetalleCarga = solicitud.DetalleCarga,
            PesoKg = solicitud.PesoKg,
            Estado = solicitud.Estado,
            FechaCreacion = solicitud.FechaCreacion
        };
    }
}
