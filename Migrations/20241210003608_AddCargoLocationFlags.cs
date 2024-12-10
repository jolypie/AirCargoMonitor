using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargosMonitor.Migrations
{
    /// <inheritdoc />
    public partial class AddCargoLocationFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 20);

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
                columns: new[] { "CargoCode", "Description", "IsInAirplane", "IsInWarehouse", "WarehouseId", "Weight" },
                values: new object[] { "C106", "Machinery Parts", false, false, null, 1500m });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 6,
                columns: new[] { "CargoCode", "Description", "IsInAirplane", "IsInWarehouse", "Status", "WarehouseId", "Weight" },
                values: new object[] { "C108", "Industrial Equipment", false, true, 0, 1, 1200m });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                columns: new[] { "CargoCode", "Description", "IsInAirplane", "IsInWarehouse", "WarehouseId", "Weight" },
                values: new object[] { "C112", "Automotive Parts", false, false, null, 900m });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "CargoCode", "Description", "IsInAirplane", "IsInWarehouse", "WarehouseId", "Weight" },
                values: new object[] { "C118", "Chemical Products", false, false, null, 850m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CargoCode", "Description", "WarehouseId", "Weight" },
                values: new object[] { "C105", "Food Products", 1, 800m });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 6,
                columns: new[] { "CargoCode", "Description", "Status", "WarehouseId", "Weight" },
                values: new object[] { "C106", "Machinery Parts", 2, null, 1500m });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                columns: new[] { "CargoCode", "Description", "WarehouseId", "Weight" },
                values: new object[] { "C107", "Household Goods", 2, 700m });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "CargoCode", "Description", "WarehouseId", "Weight" },
                values: new object[] { "C108", "Industrial Equipment", 1, 1200m });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CargoId", "AirplaneId", "CargoCode", "Description", "Status", "WarehouseId", "Weight" },
                values: new object[,]
                {
                    { 9, null, "C109", "Toys", 0, 1, 400m },
                    { 10, null, "C110", "Books", 0, 2, 600m },
                    { 11, null, "C111", "Office Supplies", 0, 1, 550m },
                    { 12, null, "C112", "Automotive Parts", 2, null, 900m },
                    { 13, null, "C113", "Construction Materials", 2, null, 1100m },
                    { 14, null, "C114", "Pharmaceuticals", 0, 2, 250m },
                    { 15, null, "C115", "Consumer Electronics", 0, 1, 750m },
                    { 16, null, "C116", "Textiles", 0, 1, 500m },
                    { 17, null, "C117", "Cosmetics", 0, 2, 300m },
                    { 18, null, "C118", "Chemical Products", 2, null, 850m },
                    { 19, null, "C119", "Sports Equipment", 0, 1, 400m },
                    { 20, null, "C120", "Pet Supplies", 0, 2, 600m }
                });
        }
    }
}
