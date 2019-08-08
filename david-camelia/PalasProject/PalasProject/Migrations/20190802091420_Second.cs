using Microsoft.EntityFrameworkCore.Migrations;

namespace PalasProject.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "ParkingLots",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "ParkingLots",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
