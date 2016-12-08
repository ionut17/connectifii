using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "RegistrationNumber",
                "Students",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "RegistrationNumber",
                "Students",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}