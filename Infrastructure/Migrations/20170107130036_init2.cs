using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Students_Group_GroupId",
                "Students");

            migrationBuilder.DropPrimaryKey(
                "PK_Group",
                "Group");

            migrationBuilder.RenameTable(
                "Group",
                newName: "Groups");

            migrationBuilder.AddPrimaryKey(
                "PK_Groups",
                "Groups",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Students_Groups_GroupId",
                "Students",
                "GroupId",
                "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Students_Groups_GroupId",
                "Students");

            migrationBuilder.DropPrimaryKey(
                "PK_Groups",
                "Groups");

            migrationBuilder.RenameTable(
                "Groups",
                newName: "Group");

            migrationBuilder.AddPrimaryKey(
                "PK_Group",
                "Group",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Students_Group_GroupId",
                "Students",
                "GroupId",
                "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}