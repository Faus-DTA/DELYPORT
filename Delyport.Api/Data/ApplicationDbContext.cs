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
    }
}
