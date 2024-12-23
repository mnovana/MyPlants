using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyPlants.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WaterFrequency = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BackgroundColorHex = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waterings",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    Fertilized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waterings", x => new { x.PlantId, x.Date });
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "BackgroundColorHex", "ImageName", "Name", "UserId", "WaterFrequency" },
                values: new object[,]
                {
                    { 1, "#FFD3AD", "1", "Kitchen ficus", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 10 },
                    { 2, "#8BC7FF", "1", "Bedroom ficus", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 10 },
                    { 3, "#ECFFAD", "1", "Ficus tineke", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 10 },
                    { 4, "#FFADDE", "6", "Jade plant", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 14 },
                    { 5, "#E7F3DC", "8", "Peace lilly", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 10 },
                    { 6, "#FFA8A8", "3", "Pothos", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 10 },
                    { 7, "#FFF79D", "2", "Sanseveria", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 14 },
                    { 8, "#FFA8A8", "4", "ZZ plant", "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2", 10 }
                });

            migrationBuilder.InsertData(
                table: "Waterings",
                columns: new[] { "Date", "PlantId", "Fertilized" },
                values: new object[,]
                {
                    { new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false },
                    { new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false },
                    { new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false },
                    { new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false },
                    { new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false },
                    { new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, false },
                    { new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserId",
                table: "Plants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Waterings");
        }
    }
}
