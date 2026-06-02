using Delyport.Api.Data;
using Delyport.Api.Models.DTOs;
using Delyport.Api.Models.Entities;
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
    private decimal CalcularSubtotal(TamanoProducto tamano, int cantidad)
    {
        decimal precioTamano = tamano switch
        {
            TamanoProducto.Pequeno => 3m,
            TamanoProducto.Mediano => 6m,
            TamanoProducto.Grande => 10m,
            _ => 3m
        };
        return cantidad * precioTamano;
    }

    private decimal CalcularTarifaDistrito(string distrito)
    {
        string d = distrito.Trim().ToLower();
        return d switch
        {
            "santa anita" => 40m, "el agustino" => 30m,
            "comas" => 60m, "callao" => 90m,
            _ => 50m 
        };
    }

    public async Task<IEnumerable<SolicitudResponseDto>> GetSolicitudesRegistradasAsync()
    {
        return await _context.Solicitudes
            .Include(s => s.Productos)
            .Where(s => s.Estado == EstadoSolicitud.Registrado)
            .Select(s => new SolicitudResponseDto
            {
                Id = s.Id, Codigo = s.Codigo, Cliente = s.Cliente,
                DetalleCarga = s.DetalleCarga, Direccion = s.Direccion,
                Distrito = s.Distrito, PrecioTotal = s.PrecioTotal,
                Estado = s.Estado, FechaCreacion = s.FechaCreacion,
                Productos = s.Productos.Select(p => new ProductoResponseDto
                {
                    Tamano = p.Tamano.ToString(), Cantidad = p.Cantidad, Subtotal = p.Subtotal
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<SolicitudResponseDto?> ActualizarSolicitudAsync(int id, UpdateSolicitudDto dto)
    {
        var solicitud = await _context.Solicitudes.Include(s => s.Productos).FirstOrDefaultAsync(s => s.Id == id);
        if (solicitud == null) return null;
        if (solicitud.Estado != EstadoSolicitud.Registrado)
            throw new InvalidOperationException("Solo se pueden modificar las solicitudes que se encuentran en estado Registrado.");

        solicitud.Cliente = dto.Cliente;
        solicitud.DetalleCarga = dto.DetalleCarga;
        solicitud.Direccion = dto.Direccion;
        solicitud.Distrito = dto.Distrito;

        _context.Set<SolicitudProducto>().RemoveRange(solicitud.Productos);

        decimal sumaProductos = 0;
        var nuevosProductos = new List<SolicitudProducto>();
        foreach(var prod in dto.Productos) {
            var sub = CalcularSubtotal((TamanoProducto)prod.Tamano, prod.Cantidad);
            sumaProductos += sub;
            nuevosProductos.Add(new SolicitudProducto { Tamano = (TamanoProducto)prod.Tamano, Cantidad = prod.Cantidad, Subtotal = sub });
        }

        solicitud.Productos = nuevosProductos;
        solicitud.PrecioTotal = sumaProductos + CalcularTarifaDistrito(dto.Distrito);

        _context.Solicitudes.Update(solicitud);
        await _context.SaveChangesAsync(); 

        return new SolicitudResponseDto
        {
            Id = solicitud.Id, Codigo = solicitud.Codigo, Cliente = solicitud.Cliente,
            DetalleCarga = solicitud.DetalleCarga, Direccion = solicitud.Direccion,
            Distrito = solicitud.Distrito, PrecioTotal = solicitud.PrecioTotal,
            Estado = solicitud.Estado, FechaCreacion = solicitud.FechaCreacion,
            Productos = solicitud.Productos.Select(p => new ProductoResponseDto { Tamano = p.Tamano.ToString(), Cantidad = p.Cantidad, Subtotal = p.Subtotal }).ToList()
        };
    }

    public async Task<SolicitudResponseDto> CrearSolicitudAsync(CrearSolicitudDto dto)
    {
        decimal sumaProductos = 0;
        var nuevosProductos = new List<SolicitudProducto>();
        foreach(var prod in dto.Productos) {
            var sub = CalcularSubtotal((TamanoProducto)prod.Tamano, prod.Cantidad);
            sumaProductos += sub;
            nuevosProductos.Add(new SolicitudProducto { Tamano = (TamanoProducto)prod.Tamano, Cantidad = prod.Cantidad, Subtotal = sub });
        }

        var nuevaSolicitud = new Models.Entities.Solicitud
        {
            Codigo = "SOL-" + new Random().Next(1000, 9999).ToString(),
            Cliente = dto.Cliente, DetalleCarga = dto.DetalleCarga,
            Direccion = dto.Direccion, Distrito = dto.Distrito,
            Productos = nuevosProductos,
            PrecioTotal = sumaProductos + CalcularTarifaDistrito(dto.Distrito),
            Estado = EstadoSolicitud.Registrado, FechaCreacion = DateTime.UtcNow
        };

        _context.Solicitudes.Add(nuevaSolicitud);
        await _context.SaveChangesAsync();

        return new SolicitudResponseDto
        {
            Id = nuevaSolicitud.Id, Codigo = nuevaSolicitud.Codigo, Cliente = nuevaSolicitud.Cliente,
            DetalleCarga = nuevaSolicitud.DetalleCarga, Direccion = nuevaSolicitud.Direccion,
            Distrito = nuevaSolicitud.Distrito, PrecioTotal = nuevaSolicitud.PrecioTotal,
            Estado = nuevaSolicitud.Estado, FechaCreacion = nuevaSolicitud.FechaCreacion,
            Productos = nuevaSolicitud.Productos.Select(p => new ProductoResponseDto { Tamano = p.Tamano.ToString(), Cantidad = p.Cantidad, Subtotal = p.Subtotal }).ToList()
        };
    }
}
