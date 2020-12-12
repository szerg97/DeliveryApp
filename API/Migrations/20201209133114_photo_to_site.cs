using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class photo_to_site : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_AspNetUsers_AppUserId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AppUserId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "SiteId",
                table: "Photo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_SiteId",
                table: "Photo",
                column: "SiteId",
                unique: true,
                filter: "[SiteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Sites_SiteId",
                table: "Photo",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "SiteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Sites_SiteId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_SiteId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Photo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AppUserId",
                table: "Photo",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_AspNetUsers_AppUserId",
                table: "Photo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
