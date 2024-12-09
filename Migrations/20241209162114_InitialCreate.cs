using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargosMonitor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirplaneCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaxLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.AirplaneId);
                    table.ForeignKey(
                        name: "FK_Airplanes_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                    table.ForeignKey(
                        name: "FK_Cargos_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "AirplaneId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Cargos_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CargoId", "AirplaneId", "CargoCode", "Status", "WarehouseId", "Weight" },
                values: new object[,]
                {
                    { 3, null, "C103", 2, null, 1000m },
                    { 6, null, "C106", 2, null, 1500m },
                    { 8, null, "C108", 2, null, 1200m }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "Location", "WarehouseCode" },
                values: new object[] { 1, "New York", "W101" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "AirplaneId", "AirplaneCode", "CurrentLoad", "MaxLoad", "WarehouseId" },
                values: new object[,]
                {
                    { 1, "A101", 0m, 50000m, 1 },
                    { 2, "A102", 0m, 60000m, 1 },
                    { 3, "A103", 0m, 45000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "CargoId", "AirplaneId", "CargoCode", "Status", "WarehouseId", "Weight" },
                values: new object[,]
                {
                    { 1, null, "C101", 0, 1, 500m },
                    { 2, null, "C102", 0, 1, 300m },
                    { 7, null, "C107", 0, 1, 700m },
                    { 10, null, "C110", 0, 1, 600m },
                    { 4, 1, "C104", 1, null, 200m },
                    { 5, 2, "C105", 1, null, 800m },
                    { 9, 3, "C109", 1, null, 400m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_WarehouseId",
                table: "Airplanes",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_AirplaneId",
                table: "Cargos",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_WarehouseId",
                table: "Cargos",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
