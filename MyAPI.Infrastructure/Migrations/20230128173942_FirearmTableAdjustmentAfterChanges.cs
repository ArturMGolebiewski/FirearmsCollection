using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.Infrastructure.Migrations
{
    public partial class FirearmTableAdjustmentAfterChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirearmType",
                table: "Firearms");

            migrationBuilder.AddColumn<Guid>(
                name: "FirearmTypeId",
                table: "Firearms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Firearms_FirearmTypeId",
                table: "Firearms",
                column: "FirearmTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Firearms_FirearmType_FirearmTypeId",
                table: "Firearms",
                column: "FirearmTypeId",
                principalTable: "FirearmType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firearms_FirearmType_FirearmTypeId",
                table: "Firearms");

            migrationBuilder.DropIndex(
                name: "IX_Firearms_FirearmTypeId",
                table: "Firearms");

            migrationBuilder.DropColumn(
                name: "FirearmTypeId",
                table: "Firearms");

            migrationBuilder.AddColumn<string>(
                name: "FirearmType",
                table: "Firearms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
