using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class GroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Group",
                "Students");

            migrationBuilder.AddColumn<Guid>(
                "GroupId",
                "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                "Group",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Group", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Students_GroupId",
                "Students",
                "GroupId");

            migrationBuilder.AddForeignKey(
                "FK_Students_Group_GroupId",
                "Students",
                "GroupId",
                "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Students_Group_GroupId",
                "Students");

            migrationBuilder.DropTable(
                "Group");

            migrationBuilder.DropIndex(
                "IX_Students_GroupId",
                "Students");

            migrationBuilder.DropColumn(
                "GroupId",
                "Students");

            migrationBuilder.AddColumn<string>(
                "Group",
                "Students",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}