using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargosMonitor.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampToCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedToAirplaneAt",
                table: "Cargos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedToWarehouseAt",
                table: "Cargos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 1,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 2,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 3,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 4,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 5,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 6,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "AddedToAirplaneAt", "AddedToWarehouseAt" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedToAirplaneAt",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "AddedToWarehouseAt",
                table: "Cargos");
        }
    }
}
