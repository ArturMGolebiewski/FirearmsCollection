using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.Infrastructure.Migrations
{
    public partial class DeletingCaliberFromFirearms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caliber",
                table: "Firearms");

            migrationBuilder.AddColumn<Guid>(
                name: "CaliberId",
                table: "Firearms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Calibers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaliberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firearms_CaliberId",
                table: "Firearms",
                column: "CaliberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Firearms_Calibers_CaliberId",
                table: "Firearms",
                column: "CaliberId",
                principalTable: "Calibers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firearms_Calibers_CaliberId",
                table: "Firearms");

            migrationBuilder.DropTable(
                name: "Calibers");

            migrationBuilder.DropIndex(
                name: "IX_Firearms_CaliberId",
                table: "Firearms");

            migrationBuilder.DropColumn(
                name: "CaliberId",
                table: "Firearms");

            migrationBuilder.AddColumn<string>(
                name: "Caliber",
                table: "Firearms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
