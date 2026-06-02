using Delyport.Api.Data;
using Delyport.Api.Models.DTOs;
using Delyport.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delyport.Api.Services;

public class AsignacionService : IAsignacionService
{
    private readonly ApplicationDbContext _context;

    public AsignacionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AsignacionServicio>> GetAllAsignacionesAsync()
    {
        return await _context.AsignacionesServicio.OrderByDescending(x => x.Id).ToListAsync();
    }

    public async Task<AsignacionServicio?> GetAsignacionByIdAsync(int id)
    {
        var servicio = await _context.AsignacionesServicio
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
            
        return servicio;
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

    public async Task<AsignacionServicio> CrearDesdeSolicitudAsync(int solicitudId)
    {
        var solicitud = await _context.Solicitudes.Include(s => s.Productos).FirstOrDefaultAsync(s => s.Id == solicitudId);
        if (solicitud == null) throw new InvalidOperationException("Solicitud no encontrada");
        
        if (solicitud.Estado == Models.Enums.EstadoSolicitud.Aprobado)
            throw new InvalidOperationException("La solicitud ya fue aprobada y asignada.");

        // Crear la asignación basada en la solicitud
        var asignacion = new AsignacionServicio
        {
            CodigoServicio = "SRV-" + new Random().Next(1000, 9999).ToString(),
            ConductorId = 100 + new Random().Next(1, 10), // Conductor dummy
            Descripcion = $"Entrega a {solicitud.Cliente}: {solicitud.DetalleCarga}",
            Origen = "Almacén Central Santa Anita",
            Destino = solicitud.Distrito,
            FechaAsignacion = DateTime.UtcNow,
            Tarifa = solicitud.PrecioTotal,
            Estado = Models.Enums.EstadoServicio.Pendiente
        };

        _context.AsignacionesServicio.Add(asignacion);

        // Marcar la solicitud como aprobada
        solicitud.Estado = Models.Enums.EstadoSolicitud.Aprobado;
        _context.Solicitudes.Update(solicitud);

        await _context.SaveChangesAsync();

        return asignacion;
    }

    public async Task<bool> ResponderAsignacionAsync(int id, RespuestaAsignacionDto respuesta)
    {
        var servicio = await _context.AsignacionesServicio.FindAsync(id);

        if (servicio == null)
            return false;
            
        if (servicio.Estado != Models.Enums.EstadoServicio.Pendiente)
            return false;

        // TASK-025: Actualizar estado del servicio a "En proceso" al ser aceptado
        if (respuesta.Aceptar)
        {
            servicio.Estado = Models.Enums.EstadoServicio.EnProceso;
            servicio.ConductorId = respuesta.ConductorId;
        }
        else
        {
            servicio.Estado = Models.Enums.EstadoServicio.Rechazado;
            // Se podría guardar el motivo si la entidad AsignacionServicio tuviese el campo
        }

        _context.AsignacionesServicio.Update(servicio);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CambioEstadoResponseDto?> ActualizarEstadoAsync(int id, CambioEstadoRequestDto request)
    {
        var servicio = await _context.AsignacionesServicio.FindAsync(id);

        if (servicio == null)
            return null;

        // Regla de negocio: No se puede cambiar al mismo estado
        if (servicio.Estado == request.EstadoNuevo)
        {
            return new CambioEstadoResponseDto
            {
                IdServicio = servicio.Id,
                EstadoActual = servicio.Estado,
                FechaActualizacion = DateTime.UtcNow,
                Mensaje = "El servicio ya se encuentra en el estado solicitado."
            };
        }

        var estadoAnterior = servicio.Estado;

        // 1. Modificar el registro del servicio principal en la BD con el nuevo estado (TASK-030)
        servicio.Estado = request.EstadoNuevo;

        // 2. Crear el registro en el historial (TASK-029)
        var historial = new HistorialEstado
        {
            AsignacionServicioId = servicio.Id,
            EstadoAnterior = estadoAnterior,
            EstadoNuevo = request.EstadoNuevo,
            Observacion = request.Observacion,
            FechaCambio = DateTime.UtcNow
        };

        _context.HistorialEstados.Add(historial);
        _context.AsignacionesServicio.Update(servicio);
        
        await _context.SaveChangesAsync();

        // 3. Retornar DTO de salida optimizado (TASK-031)
        return new CambioEstadoResponseDto
        {
            IdServicio = servicio.Id,
            EstadoActual = servicio.Estado,
            FechaActualizacion = DateTime.UtcNow,
            Mensaje = "Estado actualizado y registrado en el historial correctamente."
        };
    }
}
