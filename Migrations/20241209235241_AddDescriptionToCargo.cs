using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargosMonitor.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cargos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 1,
                column: "Description",
                value: "Electronics");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 2,
                column: "Description",
                value: "Clothing");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 3,
                columns: new[] { "Description", "Status", "WarehouseId" },
                values: new object[] { "Furniture", 0, 1 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 4,
                columns: new[] { "AirplaneId", "Description", "Status", "WarehouseId" },
                values: new object[] { null, "Medical Supplies", 0, 2 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 5,
                columns: new[] { "AirplaneId", "Description", "Status", "WarehouseId" },
                values: new object[] { null, "Food Products", 0, 1 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 6,
                column: "Description",
                value: "Machinery Parts");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                columns: new[] { "Description", "WarehouseId" },
                values: new object[] { "Household Goods", 2 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "Description", "Status", "WarehouseId" },
                values: new object[] { "Industrial Equipment", 0, 1 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 9,
                columns: new[] { "AirplaneId", "Description", "Status", "WarehouseId" },
                values: new object[] { null, "Toys", 0, 1 });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 10,
                columns: new[] { "Description", "WarehouseId" },
                values: new object[] { "Books", 2 });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CargoId", "AirplaneId", "CargoCode", "Description", "Status", "WarehouseId", "Weight" },
                values: new object[,]
                {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cargos");

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 3,
                columns: new[] { "Status", "WarehouseId" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 4,
                columns: new[] { "AirplaneId", "Status", "WarehouseId" },
                values: new object[] { 1, 1, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 5,
                columns: new[] { "AirplaneId", "Status", "WarehouseId" },
                values: new object[] { 2, 1, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 7,
                column: "WarehouseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 8,
                columns: new[] { "Status", "WarehouseId" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 9,
                columns: new[] { "AirplaneId", "Status", "WarehouseId" },
                values: new object[] { 3, 1, null });

            migrationBuilder.UpdateData(
                table: "Cargos",
                keyColumn: "CargoId",
                keyValue: 10,
                column: "WarehouseId",
                value: 1);
        }
    }
}
