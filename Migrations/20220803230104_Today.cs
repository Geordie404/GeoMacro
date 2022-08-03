using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeosMacros.Migrations
{
    public partial class Today : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Today",
                table: "Nutrition",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Today",
                table: "Nutrition");
        }
    }
}
