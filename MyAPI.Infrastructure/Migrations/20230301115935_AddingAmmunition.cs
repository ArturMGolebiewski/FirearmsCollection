using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.Infrastructure.Migrations
{
    public partial class AddingAmmunition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ammunition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaliberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirearmTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammunition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ammunition_Calibers_CaliberId",
                        column: x => x.CaliberId,
                        principalTable: "Calibers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ammunition_FirearmType_FirearmTypeId",
                        column: x => x.FirearmTypeId,
                        principalTable: "FirearmType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ammunition_CaliberId",
                table: "Ammunition",
                column: "CaliberId");

            migrationBuilder.CreateIndex(
                name: "IX_Ammunition_FirearmTypeId",
                table: "Ammunition",
                column: "FirearmTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ammunition");
        }
    }
}
