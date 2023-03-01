using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.Infrastructure.Migrations
{
    public partial class DeletingManufacturerFromFirearm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturerName",
                table: "Firearms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManufacturerName",
                table: "Firearms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
