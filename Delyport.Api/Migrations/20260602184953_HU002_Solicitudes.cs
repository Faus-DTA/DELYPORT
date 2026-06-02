using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delyport.Api.Migrations
{
    /// <inheritdoc />
    public partial class HU002_Solicitudes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsignacionesServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoServicio = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Origen = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Destino = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConductorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Cliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DetalleCarga = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PesoKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AsignacionServicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoAnterior = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoNuevo = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialEstados_AsignacionesServicio_AsignacionServicioId",
                        column: x => x.AsignacionServicioId,
                        principalTable: "AsignacionesServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AsignacionesServicio",
                columns: new[] { "Id", "CodigoServicio", "ConductorId", "Descripcion", "Destino", "Estado", "FechaAsignacion", "Origen", "Tarifa" },
                values: new object[,]
                {
                    { 1, "SRV-001", null, "Entrega de contenedor 40ft (Electrónicos)", "Almacén Central Delyport (San Isidro)", 0, new DateTime(2026, 6, 2, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(42), "Puerto del Callao", 1500.00m },
                    { 2, "SRV-002", null, "Traslado de repuestos automotrices", "Taller Delyport (Surquillo)", 0, new DateTime(2026, 6, 2, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(46), "Puerto del Callao", 850.50m }
                });

            migrationBuilder.InsertData(
                table: "Solicitudes",
                columns: new[] { "Id", "Cliente", "Codigo", "DetalleCarga", "Estado", "FechaCreacion", "PesoKg" },
                values: new object[,]
                {
                    { 1, "Importaciones XYZ", "SOL-100", "10 Cajas de Teclados Mecánicos", 0, new DateTime(2026, 6, 2, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(138), 150.5m },
                    { 2, "Comercial Alfa", "SOL-101", "Repuestos de maquinaria agrícola", 1, new DateTime(2026, 6, 1, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(141), 850.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEstados_AsignacionServicioId",
                table: "HistorialEstados",
                column: "AsignacionServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialEstados");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "AsignacionesServicio");
        }
    }
}
