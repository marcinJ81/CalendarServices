using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarServices.Migrations
{
    public partial class addnewproptoclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteSeriveces",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeServices_id",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteSeriveces",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TypeServices_id",
                table: "Customers");
        }
    }
}
