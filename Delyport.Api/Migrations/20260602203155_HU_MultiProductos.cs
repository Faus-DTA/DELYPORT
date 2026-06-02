using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delyport.Api.Migrations
{
    /// <inheritdoc />
    public partial class HU_MultiProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadProductos",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Tamano",
                table: "Solicitudes");

            migrationBuilder.CreateTable(
                name: "SolicitudProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SolicitudId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tamano = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudProductos_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConductorId", "Descripcion", "Destino", "FechaAsignacion", "Origen", "Tarifa" },
                values: new object[] { 100, "Ruta de entrega #1", "Santa Anita", new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8188), "Puerto Callao", 150.0m });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConductorId", "Descripcion", "Destino", "Estado", "FechaAsignacion", "Origen", "Tarifa" },
                values: new object[] { 101, "Ruta de entrega #2", "Comas", 1, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8197), "Almacen Central", 160.0m });

            migrationBuilder.InsertData(
                table: "AsignacionesServicio",
                columns: new[] { "Id", "CodigoServicio", "ConductorId", "Descripcion", "Destino", "Estado", "FechaAsignacion", "Origen", "Tarifa" },
                values: new object[,]
                {
                    { 3, "SRV-003", 102, "Ruta de entrega #3", "El Agustino", 3, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8200), "Sede Lurin", 170.0m },
                    { 4, "SRV-004", 103, "Ruta de entrega #4", "Los Olivos", 3, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8202), "Oficina San Isidro", 180.0m },
                    { 5, "SRV-005", 104, "Ruta de entrega #5", "Miraflores", 0, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8204), "Puerto Callao", 190.0m },
                    { 6, "SRV-006", 105, "Ruta de entrega #6", "Santa Anita", 2, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8205), "Almacen Central", 200.0m },
                    { 7, "SRV-007", 106, "Ruta de entrega #7", "Comas", 3, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8207), "Sede Lurin", 210.0m },
                    { 8, "SRV-008", 107, "Ruta de entrega #8", "El Agustino", 1, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8209), "Oficina San Isidro", 220.0m },
                    { 9, "SRV-009", 108, "Ruta de entrega #9", "Los Olivos", 0, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8211), "Puerto Callao", 230.0m },
                    { 10, "SRV-0010", 109, "Ruta de entrega #10", "Miraflores", 3, new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8216), "Almacen Central", 240.0m }
                });

            migrationBuilder.InsertData(
                table: "SolicitudProductos",
                columns: new[] { "Id", "Cantidad", "SolicitudId", "Subtotal", "Tamano" },
                values: new object[,]
                {
                    { 1, 1, 1, 3m, 0 },
                    { 2, 2, 2, 12m, 1 },
                    { 11, 2, 1, 20m, 2 },
                    { 12, 2, 2, 20m, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cliente", "DetalleCarga", "Direccion", "FechaCreacion", "PrecioTotal" },
                values: new object[] { "Cliente 1", "Carga comercial #1", "Av. Prueba 0", new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8326), 0m });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cliente", "DetalleCarga", "Direccion", "Estado", "FechaCreacion", "PrecioTotal" },
                values: new object[] { "Cliente 2", "Carga comercial #2", "Av. Prueba 10", 0, new DateTime(2026, 6, 1, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8332), 0m });

            migrationBuilder.InsertData(
                table: "Solicitudes",
                columns: new[] { "Id", "Cliente", "Codigo", "DetalleCarga", "Direccion", "Distrito", "Estado", "FechaCreacion", "PrecioTotal" },
                values: new object[,]
                {
                    { 3, "Cliente 3", "SOL-102", "Carga comercial #3", "Av. Prueba 20", "El Agustino", 1, new DateTime(2026, 5, 31, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8334), 0m },
                    { 4, "Cliente 4", "SOL-103", "Carga comercial #4", "Av. Prueba 30", "Callao", 2, new DateTime(2026, 5, 30, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8337), 0m },
                    { 5, "Cliente 5", "SOL-104", "Carga comercial #5", "Av. Prueba 40", "Santa Anita", 0, new DateTime(2026, 5, 29, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8339), 0m },
                    { 6, "Cliente 6", "SOL-105", "Carga comercial #6", "Av. Prueba 50", "Comas", 1, new DateTime(2026, 5, 28, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8341), 0m },
                    { 7, "Cliente 7", "SOL-106", "Carga comercial #7", "Av. Prueba 60", "El Agustino", 0, new DateTime(2026, 5, 27, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8343), 0m },
                    { 8, "Cliente 8", "SOL-107", "Carga comercial #8", "Av. Prueba 70", "Callao", 2, new DateTime(2026, 5, 26, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8345), 0m },
                    { 9, "Cliente 9", "SOL-108", "Carga comercial #9", "Av. Prueba 80", "Santa Anita", 0, new DateTime(2026, 5, 25, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8347), 0m },
                    { 10, "Cliente 10", "SOL-109", "Carga comercial #10", "Av. Prueba 90", "Comas", 1, new DateTime(2026, 5, 24, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8349), 0m }
                });

            migrationBuilder.InsertData(
                table: "SolicitudProductos",
                columns: new[] { "Id", "Cantidad", "SolicitudId", "Subtotal", "Tamano" },
                values: new object[,]
                {
                    { 3, 3, 3, 30m, 2 },
                    { 4, 4, 4, 12m, 0 },
                    { 5, 5, 5, 30m, 1 },
                    { 6, 1, 6, 10m, 2 },
                    { 7, 2, 7, 6m, 0 },
                    { 8, 3, 8, 18m, 1 },
                    { 9, 4, 9, 40m, 2 },
                    { 10, 5, 10, 15m, 0 },
                    { 13, 2, 3, 20m, 2 },
                    { 14, 2, 4, 20m, 2 },
                    { 15, 2, 5, 20m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudProductos_SolicitudId",
                table: "SolicitudProductos",
                column: "SolicitudId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudProductos");

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<int>(
                name: "CantidadProductos",
                table: "Solicitudes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tamano",
                table: "Solicitudes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConductorId", "Descripcion", "Destino", "FechaAsignacion", "Origen", "Tarifa" },
                values: new object[] { null, "Entrega de contenedor 40ft (Electrónicos)", "Almacén Central Delyport (San Isidro)", new DateTime(2026, 6, 2, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9045), "Puerto del Callao", 1500.00m });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConductorId", "Descripcion", "Destino", "Estado", "FechaAsignacion", "Origen", "Tarifa" },
                values: new object[] { null, "Traslado de repuestos automotrices", "Taller Delyport (Surquillo)", 0, new DateTime(2026, 6, 2, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9049), "Puerto del Callao", 850.50m });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CantidadProductos", "Cliente", "DetalleCarga", "Direccion", "FechaCreacion", "PrecioTotal", "Tamano" },
                values: new object[] { 10, "Importaciones XYZ", "10 Cajas de Teclados Mecánicos", "Av. Los Fresnos 123", new DateTime(2026, 6, 2, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9160), 100m, 1 });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CantidadProductos", "Cliente", "DetalleCarga", "Direccion", "Estado", "FechaCreacion", "PrecioTotal", "Tamano" },
                values: new object[] { 5, "Comercial Alfa", "Repuestos de maquinaria", "Jr. Progreso 45", 1, new DateTime(2026, 6, 1, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9163), 110m, 2 });
        }
    }
}
