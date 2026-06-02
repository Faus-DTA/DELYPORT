using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delyport.Api.Migrations
{
    /// <inheritdoc />
    public partial class HU_OrigenSantaAnita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9347), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9364), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9368), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9370), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9372), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9374), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9376), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9378), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9379), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9386), "Almacén Central Santa Anita" });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 6, 1, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 31, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 30, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 29, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 28, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 27, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 26, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 25, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 24, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9537));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8188), "Puerto Callao" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8197), "Almacen Central" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8200), "Sede Lurin" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8202), "Oficina San Isidro" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8204), "Puerto Callao" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8205), "Almacen Central" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8207), "Sede Lurin" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8209), "Oficina San Isidro" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8211), "Puerto Callao" });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FechaAsignacion", "Origen" },
                values: new object[] { new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8216), "Almacen Central" });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 6, 2, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 6, 1, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 31, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 30, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 29, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 28, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 27, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 26, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 25, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 24, 20, 31, 54, 907, DateTimeKind.Utc).AddTicks(8349));
        }
    }
}
