using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class MovingResetsOnToFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetsOn",
                table: "equipments");

            migrationBuilder.AddColumn<string>(
                name: "ResetsOn",
                table: "features",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetsOn",
                table: "features");

            migrationBuilder.AddColumn<string>(
                name: "ResetsOn",
                table: "equipments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
