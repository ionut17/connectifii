using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class merged : Migration
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
                "Groups",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 2, nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.UniqueConstraint("AK_Groups_Year_Name", x => new {x.Year, x.Name});
                });

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
                    RegistrationNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.UniqueConstraint("AK_Students_RegistrationNumber", x => x.RegistrationNumber);
                    table.ForeignKey(
                        "FK_Students_Groups_GroupId",
                        x => x.GroupId,
                        "Groups",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TeacherCourses",
                table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new {x.CourseId, x.TeacherId});
                    table.ForeignKey(
                        "FK_TeacherCourses_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TeacherCourses_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "StudentCourses",
                table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    StudentRegistrationNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new {x.CourseId, x.StudentId});
                    table.ForeignKey(
                        "FK_StudentCourses_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StudentCourses_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Students_GroupId",
                "Students",
                "GroupId");

            migrationBuilder.CreateIndex(
                "IX_StudentCourses_StudentId",
                "StudentCourses",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_TeacherCourses_TeacherId",
                "TeacherCourses",
                "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "StudentCourses");

            migrationBuilder.DropTable(
                "TeacherCourses");

            migrationBuilder.DropTable(
                "Students");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Teachers");

            migrationBuilder.DropTable(
                "Groups");
        }
    }
}