using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                "PK_Students",
                "Students");

            migrationBuilder.AlterColumn<string>(
                "RegistrationNumber",
                "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                "Id",
                "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                "PK_Students",
                "Students",
                "Id");

            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        "FK_Courses_Students_StudentId",
                        x => x.StudentId,
                        "Students",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
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
                "TeacherCourse",
                table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false),
                    CourseId1 = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourse", x => new {x.CourseId, x.TeacherId});
                    table.UniqueConstraint("AK_TeacherCourse_CourseId", x => x.CourseId);
                    table.ForeignKey(
                        "FK_TeacherCourse_Courses_CourseId1",
                        x => x.CourseId1,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TeacherCourse_Teachers_TeacherId",
                        x => x.TeacherId,
                        "Teachers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Courses_StudentId",
                "Courses",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_TeacherCourse_CourseId1",
                "TeacherCourse",
                "CourseId1");

            migrationBuilder.CreateIndex(
                "IX_TeacherCourse_TeacherId",
                "TeacherCourse",
                "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "TeacherCourse");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Teachers");

            migrationBuilder.DropPrimaryKey(
                "PK_Students",
                "Students");

            migrationBuilder.DropColumn(
                "Id",
                "Students");

            migrationBuilder.AlterColumn<string>(
                "RegistrationNumber",
                "Students",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                "PK_Students",
                "Students",
                "RegistrationNumber");
        }
    }
}