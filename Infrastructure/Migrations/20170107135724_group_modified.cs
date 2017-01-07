using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class group_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Year",
                "Students");

            migrationBuilder.AddColumn<int>(
                "Year",
                "Groups",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                "AK_Groups_Year_Name",
                "Groups",
                new[] {"Year", "Name"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                "AK_Groups_Year_Name",
                "Groups");

            migrationBuilder.DropColumn(
                "Year",
                "Groups");

            migrationBuilder.AddColumn<int>(
                "Year",
                "Students",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);
        }
    }
}