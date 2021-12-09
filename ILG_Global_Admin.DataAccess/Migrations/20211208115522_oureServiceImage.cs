using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global_Admin.DataAccess.Migrations
{
    public partial class oureServiceImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "OurServiceMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "OurServiceMasters");
        }
    }
}
