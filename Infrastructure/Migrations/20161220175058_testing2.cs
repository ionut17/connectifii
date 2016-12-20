using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class testing2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StudentCourse_Courses_CourseId1",
                "StudentCourse");

            migrationBuilder.DropUniqueConstraint(
                "AK_StudentCourse_CourseId",
                "StudentCourse");

            migrationBuilder.DropIndex(
                "IX_StudentCourse_CourseId1",
                "StudentCourse");

            migrationBuilder.DropColumn(
                "CourseId1",
                "StudentCourse");

            migrationBuilder.AddForeignKey(
                "FK_StudentCourse_Courses_CourseId",
                "StudentCourse",
                "CourseId",
                "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StudentCourse_Courses_CourseId",
                "StudentCourse");

            migrationBuilder.AddColumn<Guid>(
                "CourseId1",
                "StudentCourse",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                "AK_StudentCourse_CourseId",
                "StudentCourse",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_StudentCourse_CourseId1",
                "StudentCourse",
                "CourseId1");

            migrationBuilder.AddForeignKey(
                "FK_StudentCourse_Courses_CourseId1",
                "StudentCourse",
                "CourseId1",
                "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}