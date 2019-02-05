using Microsoft.EntityFrameworkCore.Migrations;

namespace Debts.Data.Migrations
{
    public partial class debt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Member2",
                table: "Debts",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Member2",
                table: "Debts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
