using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMyWebAPI.Migrations
{
    public partial class RenewRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "RefreshToken",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "RefreshToken",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "RefreshToken");
        }
    }
}