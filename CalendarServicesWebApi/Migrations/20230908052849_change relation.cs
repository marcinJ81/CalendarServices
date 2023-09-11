using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarServices.Migrations
{
    public partial class changerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Calendars_Calendar_Id",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_HairDressers_Calendars_Calendar_Id",
                table: "HairDressers");

            migrationBuilder.DropIndex(
                name: "IX_HairDressers_Calendar_Id",
                table: "HairDressers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Calendar_Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Calendar_Id",
                table: "HairDressers");

            migrationBuilder.DropColumn(
                name: "Calendar_Id",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_Customer_Id",
                table: "Calendars",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_Service_Id",
                table: "Calendars",
                column: "Service_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Customers_Customer_Id",
                table: "Calendars",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_HairDressers_Service_Id",
                table: "Calendars",
                column: "Service_Id",
                principalTable: "HairDressers",
                principalColumn: "Service_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Customers_Customer_Id",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_HairDressers_Service_Id",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_Customer_Id",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_Service_Id",
                table: "Calendars");

            migrationBuilder.AddColumn<int>(
                name: "Calendar_Id",
                table: "HairDressers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Calendar_Id",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HairDressers_Calendar_Id",
                table: "HairDressers",
                column: "Calendar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Calendar_Id",
                table: "Customers",
                column: "Calendar_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Calendars_Calendar_Id",
                table: "Customers",
                column: "Calendar_Id",
                principalTable: "Calendars",
                principalColumn: "Calendar_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HairDressers_Calendars_Calendar_Id",
                table: "HairDressers",
                column: "Calendar_Id",
                principalTable: "Calendars",
                principalColumn: "Calendar_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
