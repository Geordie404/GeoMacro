using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeosMacros.Migrations
{
    public partial class Todaytrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Today",
                table: "Nutrition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Today",
                table: "Nutrition",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
