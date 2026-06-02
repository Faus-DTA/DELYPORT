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

    // Lógica privada de cotización
    private decimal CalcularPrecioTotal(string distrito, TamanoProducto tamano, int cantidad)
    {
        // 1. Calcular precio por tamaño
        decimal precioTamano = tamano switch
        {
            TamanoProducto.Pequeno => 3m,
            TamanoProducto.Mediano => 6m,
            TamanoProducto.Grande => 10m,
            _ => 3m
        };

        // 2. Calcular tarifa por distrito
        string d = distrito.Trim().ToLower();
        decimal tarifaDistrito = d switch
        {
            "santa anita" => 40m,
            "el agustino" => 30m,
            "comas" => 60m,
            "callao" => 90m,
            _ => 50m // Tarifa base para otros distritos no mapeados
        };

        return (cantidad * precioTamano) + tarifaDistrito;
    }

    public async Task<IEnumerable<SolicitudResponseDto>> GetSolicitudesRegistradasAsync()
    {
        return await _context.Solicitudes
            .Where(s => s.Estado == EstadoSolicitud.Registrado)
            .Select(s => new SolicitudResponseDto
            {
                Id = s.Id, Codigo = s.Codigo, Cliente = s.Cliente,
                DetalleCarga = s.DetalleCarga, Direccion = s.Direccion,
                Distrito = s.Distrito, TamanoProducto = s.Tamano.ToString(),
                CantidadProductos = s.CantidadProductos, PrecioTotal = s.PrecioTotal,
                Estado = s.Estado, FechaCreacion = s.FechaCreacion
            })
            .ToListAsync();
    }

    public async Task<SolicitudResponseDto?> ActualizarSolicitudAsync(int id, UpdateSolicitudDto dto)
    {
        var solicitud = await _context.Solicitudes.FindAsync(id);
        if (solicitud == null) return null;
        if (solicitud.Estado != EstadoSolicitud.Registrado)
            throw new InvalidOperationException("Solo se pueden modificar las solicitudes que se encuentran en estado Registrado.");

        solicitud.Cliente = dto.Cliente;
        solicitud.DetalleCarga = dto.DetalleCarga;
        solicitud.Direccion = dto.Direccion;
        solicitud.Distrito = dto.Distrito;
        solicitud.Tamano = (TamanoProducto)dto.Tamano;
        solicitud.CantidadProductos = dto.CantidadProductos;
        solicitud.PrecioTotal = CalcularPrecioTotal(dto.Distrito, solicitud.Tamano, dto.CantidadProductos);

        _context.Solicitudes.Update(solicitud);
        await _context.SaveChangesAsync(); 

        return new SolicitudResponseDto
        {
            Id = solicitud.Id, Codigo = solicitud.Codigo, Cliente = solicitud.Cliente,
            DetalleCarga = solicitud.DetalleCarga, Direccion = solicitud.Direccion,
            Distrito = solicitud.Distrito, TamanoProducto = solicitud.Tamano.ToString(),
            CantidadProductos = solicitud.CantidadProductos, PrecioTotal = solicitud.PrecioTotal,
            Estado = solicitud.Estado, FechaCreacion = solicitud.FechaCreacion
        };
    }

    public async Task<SolicitudResponseDto> CrearSolicitudAsync(CrearSolicitudDto dto)
    {
        var tamanoEnum = (TamanoProducto)dto.Tamano;
        var nuevaSolicitud = new Models.Entities.Solicitud
        {
            Codigo = "SOL-" + new Random().Next(1000, 9999).ToString(),
            Cliente = dto.Cliente,
            DetalleCarga = dto.DetalleCarga,
            Direccion = dto.Direccion,
            Distrito = dto.Distrito,
            Tamano = tamanoEnum,
            CantidadProductos = dto.CantidadProductos,
            PrecioTotal = CalcularPrecioTotal(dto.Distrito, tamanoEnum, dto.CantidadProductos),
            Estado = EstadoSolicitud.Registrado,
            FechaCreacion = DateTime.UtcNow
        };

        _context.Solicitudes.Add(nuevaSolicitud);
        await _context.SaveChangesAsync();

        return new SolicitudResponseDto
        {
            Id = nuevaSolicitud.Id, Codigo = nuevaSolicitud.Codigo, Cliente = nuevaSolicitud.Cliente,
            DetalleCarga = nuevaSolicitud.DetalleCarga, Direccion = nuevaSolicitud.Direccion,
            Distrito = nuevaSolicitud.Distrito, TamanoProducto = nuevaSolicitud.Tamano.ToString(),
            CantidadProductos = nuevaSolicitud.CantidadProductos, PrecioTotal = nuevaSolicitud.PrecioTotal,
            Estado = nuevaSolicitud.Estado, FechaCreacion = nuevaSolicitud.FechaCreacion
        };
    }
}
