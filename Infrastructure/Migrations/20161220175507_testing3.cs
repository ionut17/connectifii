using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class testing3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_TeacherCourse_Courses_CourseId1",
                "TeacherCourse");

            migrationBuilder.DropUniqueConstraint(
                "AK_TeacherCourse_CourseId",
                "TeacherCourse");

            migrationBuilder.DropIndex(
                "IX_TeacherCourse_CourseId1",
                "TeacherCourse");

            migrationBuilder.DropColumn(
                "CourseId1",
                "TeacherCourse");

            migrationBuilder.AddForeignKey(
                "FK_TeacherCourse_Courses_CourseId",
                "TeacherCourse",
                "CourseId",
                "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_TeacherCourse_Courses_CourseId",
                "TeacherCourse");

            migrationBuilder.AddColumn<Guid>(
                "CourseId1",
                "TeacherCourse",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                "AK_TeacherCourse_CourseId",
                "TeacherCourse",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_TeacherCourse_CourseId1",
                "TeacherCourse",
                "CourseId1");

            migrationBuilder.AddForeignKey(
                "FK_TeacherCourse_Courses_CourseId1",
                "TeacherCourse",
                "CourseId1",
                "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}