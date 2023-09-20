using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarServices.Migrations
{
    public partial class removefktypeservicefromclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_TypeServices_TypeService_Id",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TypeService_Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TypeService_Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TypeServices_id",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "TypeServicesName",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeServicesName",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "TypeService_Id",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeServices_id",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TypeService_Id",
                table: "Customers",
                column: "TypeService_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_TypeServices_TypeService_Id",
                table: "Customers",
                column: "TypeService_Id",
                principalTable: "TypeServices",
                principalColumn: "TypeService_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
