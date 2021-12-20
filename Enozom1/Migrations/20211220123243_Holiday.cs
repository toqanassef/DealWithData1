using Microsoft.EntityFrameworkCore.Migrations;

namespace Enozom1.Migrations
{
    public partial class Holiday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holiday",
                table: "countryHolidays");

            migrationBuilder.AddColumn<int>(
                name: "HolidayId",
                table: "countryHolidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countryHolidays_HolidayId",
                table: "countryHolidays",
                column: "HolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_countryHolidays_Holiday_HolidayId",
                table: "countryHolidays",
                column: "HolidayId",
                principalTable: "Holiday",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countryHolidays_Holiday_HolidayId",
                table: "countryHolidays");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropIndex(
                name: "IX_countryHolidays_HolidayId",
                table: "countryHolidays");

            migrationBuilder.DropColumn(
                name: "HolidayId",
                table: "countryHolidays");

            migrationBuilder.AddColumn<string>(
                name: "Holiday",
                table: "countryHolidays",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
