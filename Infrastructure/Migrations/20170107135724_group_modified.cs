using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class group_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Groups",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Groups_Year_Name",
                table: "Groups",
                columns: new[] { "Year", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Groups_Year_Name",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Students",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);
        }
    }
}
