using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photo_SiteId",
                table: "Photo");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Photo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_SiteId",
                table: "Photo",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photo_SiteId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_SiteId",
                table: "Photo",
                column: "SiteId",
                unique: true,
                filter: "[SiteId] IS NOT NULL");
        }
    }
}
