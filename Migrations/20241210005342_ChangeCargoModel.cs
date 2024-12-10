using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargosMonitor.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCargoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInAirplane",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "IsInWarehouse",
                table: "Cargos");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 5,
                columns: new[] { "AirplaneId", "CargoCode", "Status" },
                values: new object[] { 1, "C105", 1 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 6,
                column: "CargoCode",
                value: "C106");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                columns: new[] { "AirplaneId", "CargoCode", "Status" },
                values: new object[] { 2, "C107", 1 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "AirplaneId", "CargoCode", "Status" },
                values: new object[] { 3, "C108", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInAirplane",
                table: "Cargos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInWarehouse",
                table: "Cargos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 1,
                columns: new[] { "IsInAirplane", "IsInWarehouse" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 2,
                columns: new[] { "IsInAirplane", "IsInWarehouse" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 3,
                columns: new[] { "IsInAirplane", "IsInWarehouse" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 4,
                columns: new[] { "IsInAirplane", "IsInWarehouse" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 5,
                columns: new[] { "AirplaneId", "CargoCode", "IsInAirplane", "IsInWarehouse", "Status" },
                values: new object[] { null, "C106", false, false, 0 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 6,
                columns: new[] { "CargoCode", "IsInAirplane", "IsInWarehouse" },
                values: new object[] { "C108", false, true });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                columns: new[] { "AirplaneId", "CargoCode", "IsInAirplane", "IsInWarehouse", "Status" },
                values: new object[] { null, "C112", false, false, 0 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "AirplaneId", "CargoCode", "IsInAirplane", "IsInWarehouse", "Status" },
                values: new object[] { null, "C118", false, false, 0 });
        }
    }
}
