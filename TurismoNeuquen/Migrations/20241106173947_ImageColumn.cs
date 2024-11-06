using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoNeuquen.Migrations
{
    /// <inheritdoc />
    public partial class ImageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "PointsOfInterest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "PointsOfInterest");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admins",
                column: "Id");
        }
    }
}