using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoNeuquen.Migrations
{
    /// <inheritdoc />
    public partial class ChangesinPOIS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "PointsOfInterest");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PointsOfInterest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PointsOfInterest");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "PointsOfInterest",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
