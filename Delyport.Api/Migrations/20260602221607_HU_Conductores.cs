using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delyport.Api.Migrations
{
    /// <inheritdoc />
    public partial class HU_Conductores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 1, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6053) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 2, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 3, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 4, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 1, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 2, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 3, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 4, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 1, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 2, new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.InsertData(
                table: "Conductores",
                columns: new[] { "Id", "NombreCompleto", "PlacaVehiculo", "Telefono" },
                values: new object[,]
                {
                    { 1, "Juan Pérez", "ABC-123", "987654321" },
                    { 2, "Carlos Ruiz", "DEF-456", "987654322" },
                    { 3, "María Silva", "GHI-789", "987654323" },
                    { 4, "Luis Gómez", "JKL-012", "987654324" }
                });

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 6, 2, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 6, 1, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 31, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 30, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 29, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 28, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 27, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 26, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 25, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Solicitudes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 5, 24, 22, 16, 3, 664, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesServicio_ConductorId",
                table: "AsignacionesServicio",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionesServicio_Conductores_ConductorId",
                table: "AsignacionesServicio",
                column: "ConductorId",
                principalTable: "Conductores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionesServicio_Conductores_ConductorId",
                table: "AsignacionesServicio");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropIndex(
                name: "IX_AsignacionesServicio_ConductorId",
                table: "AsignacionesServicio");

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 100, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9347) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 101, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9364) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 102, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9368) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 103, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 104, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 105, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9374) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 106, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 107, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 108, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "AsignacionesServicio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConductorId", "FechaAsignacion" },
                values: new object[] { 109, new DateTime(2026, 6, 2, 20, 48, 1, 198, DateTimeKind.Utc).AddTicks(9386) });

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
    }
}
