using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addedStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Courses_Students_StudentId",
                "Courses");

            migrationBuilder.DropIndex(
                "IX_Courses_StudentId",
                "Courses");

            migrationBuilder.DropColumn(
                "StudentId",
                "Courses");

            migrationBuilder.CreateTable(
                "StudentCourse",
                table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    CourseId1 = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new {x.CourseId, x.StudentId});
                    table.UniqueConstraint("AK_StudentCourse_CourseId", x => x.CourseId);
                    table.ForeignKey(
                        "FK_StudentCourse_Courses_CourseId1",
                        x => x.CourseId1,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StudentCourse_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_StudentCourse_CourseId1",
                "StudentCourse",
                "CourseId1");

            migrationBuilder.CreateIndex(
                "IX_StudentCourse_StudentId",
                "StudentCourse",
                "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "StudentCourse");

            migrationBuilder.AddColumn<Guid>(
                "StudentId",
                "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Courses_StudentId",
                "Courses",
                "StudentId");

            migrationBuilder.AddForeignKey(
                "FK_Courses_Students_StudentId",
                "Courses",
                "StudentId",
                "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}