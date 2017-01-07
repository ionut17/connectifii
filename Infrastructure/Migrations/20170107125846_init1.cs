using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Courses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Group",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Group", x => x.Id); });

            migrationBuilder.CreateTable(
                "Teachers",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Teachers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Students",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    GroupId = table.Column<Guid>(nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        "FK_Students_Group_GroupId",
                        x => x.GroupId,
                        "Group",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Students_GroupId",
                "Students",
                "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Students");

            migrationBuilder.DropTable(
                "Teachers");

            migrationBuilder.DropTable(
                "Group");
        }
    }
}