﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMyWebAPI.Migrations
{
    public partial class AddTBACateCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCate",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_IdCate",
                table: "Car",
                column: "IdCate");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CategoryCar_IdCate",
                table: "Car",
                column: "IdCate",
                principalTable: "CategoryCar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CategoryCar_IdCate",
                table: "Car");

            migrationBuilder.DropTable(
                name: "CategoryCar");

            migrationBuilder.DropIndex(
                name: "IX_Car_IdCate",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "IdCate",
                table: "Car");
        }
    }
}
