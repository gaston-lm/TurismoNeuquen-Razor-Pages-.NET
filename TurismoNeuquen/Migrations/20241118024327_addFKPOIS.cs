using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoNeuquen.Migrations
{
    /// <inheritdoc />
    public partial class addFKPOIS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PointsOfInterest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PointsOfInterest_UserId",
                table: "PointsOfInterest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsOfInterest_Users_UserId",
                table: "PointsOfInterest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsOfInterest_Users_UserId",
                table: "PointsOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_PointsOfInterest_UserId",
                table: "PointsOfInterest");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PointsOfInterest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
