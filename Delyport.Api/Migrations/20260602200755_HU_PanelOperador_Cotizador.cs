using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delyport.Api.Migrations
{
    /// <inheritdoc />
    public partial class HU_PanelOperador_Cotizador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PesoKg",
                table: "Solicitudes",
                newName: "PrecioTotal");

            migrationBuilder.AddColumn<int>(
                name: "CantidadProductos",
                table: "Solicitudes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Solicitudes",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Solicitudes",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
                column: "FechaAsignacion",
                value: new DateTime(2026, 6, 2, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAsignacion",
                value: new DateTime(2026, 6, 2, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CantidadProductos", "Direccion", "Distrito", "FechaCreacion", "PrecioTotal", "Tamano" },
                values: new object[] { 10, "Av. Los Fresnos 123", "Santa Anita", new DateTime(2026, 6, 2, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9160), 100m, 1 });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CantidadProductos", "DetalleCarga", "Direccion", "Distrito", "FechaCreacion", "PrecioTotal", "Tamano" },
                values: new object[] { 5, "Repuestos de maquinaria", "Jr. Progreso 45", "Comas", new DateTime(2026, 6, 1, 20, 7, 52, 891, DateTimeKind.Utc).AddTicks(9163), 110m, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadProductos",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Tamano",
                table: "Solicitudes");

            migrationBuilder.RenameColumn(
                name: "PrecioTotal",
                table: "Solicitudes",
                newName: "PesoKg");

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAsignacion",
                value: new DateTime(2026, 6, 2, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAsignacion",
                value: new DateTime(2026, 6, 2, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PesoKg" },
                values: new object[] { new DateTime(2026, 6, 2, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(138), 150.5m });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DetalleCarga", "FechaCreacion", "PesoKg" },
                values: new object[] { "Repuestos de maquinaria agrícola", new DateTime(2026, 6, 1, 18, 49, 50, 188, DateTimeKind.Utc).AddTicks(141), 850.0m });
        }
    }
}
