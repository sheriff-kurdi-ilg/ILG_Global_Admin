using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global_Admin.DataAccess.Migrations
{
    public partial class successstorypdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfURL",
                table: "SucessStoryMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfURL",
                table: "SucessStoryMasters");
        }
    }
}
