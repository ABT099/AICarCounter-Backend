using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingthecartype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Motorcycle_count",
                table: "TrafficRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "car_type",
                table: "TrafficRecords",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motorcycle_count",
                table: "TrafficRecords");

            migrationBuilder.DropColumn(
                name: "car_type",
                table: "TrafficRecords");
        }
    }
}
