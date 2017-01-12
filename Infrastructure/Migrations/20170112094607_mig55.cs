using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class mig55 : Migration
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

            migrationBuilder.AddColumn<Guid>(
                "CourseId",
                "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "CourseId",
                "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Teachers_CourseId",
                "Teachers",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Students_CourseId",
                "Students",
                "CourseId");

            migrationBuilder.AddForeignKey(
                "FK_Students_Courses_CourseId",
                "Students",
                "CourseId",
                "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Teachers_Courses_CourseId",
                "Teachers",
                "CourseId",
                "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Students_Courses_CourseId",
                "Students");

            migrationBuilder.DropForeignKey(
                "FK_Teachers_Courses_CourseId",
                "Teachers");

            migrationBuilder.DropIndex(
                "IX_Teachers_CourseId",
                "Teachers");

            migrationBuilder.DropIndex(
                "IX_Students_CourseId",
                "Students");

            migrationBuilder.DropColumn(
                "CourseId",
                "Teachers");

            migrationBuilder.DropColumn(
                "CourseId",
                "Students");

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