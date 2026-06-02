using Delyport.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Delyport.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AsignacionServicio> AsignacionesServicio { get; set; }
    public DbSet<HistorialEstado> HistorialEstados { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }
    public DbSet<SolicitudProducto> SolicitudProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AsignacionServicio>()
            .Property(a => a.Tarifa)
            .HasColumnType("decimal(18,2)");
            
        modelBuilder.Entity<AsignacionServicio>()
            .HasMany(a => a.HistorialEstados)
            .WithOne(h => h.AsignacionServicio)
            .HasForeignKey(h => h.AsignacionServicioId);

        modelBuilder.Entity<Solicitud>()
            .HasMany(s => s.Productos)
            .WithOne(p => p.Solicitud)
            .HasForeignKey(p => p.SolicitudId);

        // DATA DE PRUEBA: 10 Solicitudes, 10 Asignaciones y Múltiples Productos
        // Asignaciones
        var asignaciones = new AsignacionServicio[10];
        string origenFijo = "Almacén Central Santa Anita";
        string[] destinos = { "Santa Anita", "Comas", "El Agustino", "Los Olivos", "Miraflores" };
        int[] estadosAsignacion = { 0, 1, 3, 3, 0, 2, 3, 1, 0, 3 }; // 0:Pendiente, 1:Aceptado, 2:Rechazado, 3:EnProceso
        
        for(int i=0; i<10; i++) {
            asignaciones[i] = new AsignacionServicio {
                Id = i+1, CodigoServicio = $"SRV-00{i+1}", ConductorId = 100 + i,
                Descripcion = $"Ruta de entrega #{i+1}",
                Origen = origenFijo, Destino = destinos[i%5],
                FechaAsignacion = DateTime.UtcNow, Tarifa = 150.0m + (i*10),
                Estado = (Models.Enums.EstadoServicio)estadosAsignacion[i]
            };
        }
        modelBuilder.Entity<AsignacionServicio>().HasData(asignaciones);

        // Solicitudes
        var solicitudes = new Solicitud[10];
        string[] distritos = { "Santa Anita", "Comas", "El Agustino", "Callao" };
        int[] estadosSolicitud = { 0, 0, 1, 2, 0, 1, 0, 2, 0, 1 }; // 0:Registrado, 1:Aprobado, 2:Rechazado

        for(int i=0; i<10; i++) {
            solicitudes[i] = new Solicitud {
                Id = i+1, Codigo = $"SOL-10{i}", Cliente = $"Cliente {i+1}",
                DetalleCarga = $"Carga comercial #{i+1}",
                Direccion = $"Av. Prueba {i*10}", Distrito = distritos[i%4],
                PrecioTotal = 0, // Se ignora para el seed pero se llena
                Estado = (Models.Enums.EstadoSolicitud)estadosSolicitud[i],
                FechaCreacion = DateTime.UtcNow.AddDays(-i)
            };
        }
        modelBuilder.Entity<Solicitud>().HasData(solicitudes);

        // SolicitudProductos
        var productos = new SolicitudProducto[15];
        for(int i=0; i<10; i++) {
            productos[i] = new SolicitudProducto {
                Id = i+1, SolicitudId = i+1, Tamano = (Models.Enums.TamanoProducto)(i%3),
                Cantidad = (i%5)+1, Subtotal = ((i%5)+1) * (i%3 == 0 ? 3 : (i%3 == 1 ? 6 : 10))
            };
        }
        // Algunos extra para simular multiples
        for(int i=10; i<15; i++) {
            productos[i] = new SolicitudProducto {
                Id = i+1, SolicitudId = (i%5)+1, Tamano = Models.Enums.TamanoProducto.Grande,
                Cantidad = 2, Subtotal = 20
            };
        }
        modelBuilder.Entity<SolicitudProducto>().HasData(productos);
    }
}
