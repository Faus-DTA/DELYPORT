using Microsoft.EntityFrameworkCore;
using Delyport.Api.Models.Entities;

namespace Delyport.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<AsignacionServicio> AsignacionesServicio { get; set; }
    public DbSet<HistorialEstado> HistorialEstados { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Seed data inicial para propósitos de demo
        modelBuilder.Entity<AsignacionServicio>().HasData(
            new AsignacionServicio
            {
                Id = 1,
                CodigoServicio = "SRV-001",
                Descripcion = "Entrega de contenedor 40ft (Electrónicos)",
                Origen = "Puerto del Callao",
                Destino = "Almacén Central Delyport (San Isidro)",
                Tarifa = 1500.00m,
                Estado = Models.Enums.EstadoServicio.Pendiente,
                FechaAsignacion = DateTime.UtcNow
            },
            new AsignacionServicio
            {
                Id = 2,
                CodigoServicio = "SRV-002",
                Descripcion = "Traslado de repuestos automotrices",
                Origen = "Puerto del Callao",
                Destino = "Taller Delyport (Surquillo)",
                Tarifa = 850.50m,
                Estado = Models.Enums.EstadoServicio.Pendiente,
                FechaAsignacion = DateTime.UtcNow
            }
        );

        // Seed Data para Solicitudes
        modelBuilder.Entity<Solicitud>().HasData(
            new Solicitud
            {
                Id = 1, Codigo = "SOL-100", Cliente = "Importaciones XYZ",
                DetalleCarga = "10 Cajas de Teclados Mecánicos", 
                Direccion = "Av. Los Fresnos 123", Distrito = "Santa Anita",
                Tamano = Models.Enums.TamanoProducto.Mediano, CantidadProductos = 10,
                PrecioTotal = (10 * 6) + 40, // 100
                Estado = Models.Enums.EstadoSolicitud.Registrado, FechaCreacion = DateTime.UtcNow
            },
            new Solicitud
            {
                Id = 2, Codigo = "SOL-101", Cliente = "Comercial Alfa",
                DetalleCarga = "Repuestos de maquinaria", 
                Direccion = "Jr. Progreso 45", Distrito = "Comas",
                Tamano = Models.Enums.TamanoProducto.Grande, CantidadProductos = 5,
                PrecioTotal = (5 * 10) + 60, // 110
                Estado = Models.Enums.EstadoSolicitud.Aprobado, FechaCreacion = DateTime.UtcNow.AddDays(-1)
            }
        );
    }
}
