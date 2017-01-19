using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class security3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_AspNetUserClaims_Users_UserId",
                "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                "FK_AspNetUserLogins_Users_UserId",
                "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                "FK_AspNetUserRoles_Users_UserId",
                "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                "PK_Users",
                "Users");

            migrationBuilder.RenameTable(
                "Users",
                newName: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                "PK_AspNetUsers",
                "AspNetUsers",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserClaims_AspNetUsers_UserId",
                "AspNetUserClaims",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserLogins_AspNetUsers_UserId",
                "AspNetUserLogins",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserRoles_AspNetUsers_UserId",
                "AspNetUserRoles",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_AspNetUserClaims_AspNetUsers_UserId",
                "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                "FK_AspNetUserLogins_AspNetUsers_UserId",
                "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                "FK_AspNetUserRoles_AspNetUsers_UserId",
                "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                "PK_AspNetUsers",
                "AspNetUsers");

            migrationBuilder.RenameTable(
                "AspNetUsers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                "PK_Users",
                "Users",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserClaims_Users_UserId",
                "AspNetUserClaims",
                "UserId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserLogins_Users_UserId",
                "AspNetUserLogins",
                "UserId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserRoles_Users_UserId",
                "AspNetUserRoles",
                "UserId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}