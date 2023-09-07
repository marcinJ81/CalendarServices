using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarServices.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Calendar_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calendar_ReservationDate = table.Column<DateTime>(nullable: false),
                    Calendar_Deleted = table.Column<bool>(nullable: false),
                    Service_Id = table.Column<int>(nullable: true),
                    Customer_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Calendar_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customer_Name = table.Column<string>(nullable: true),
                    Customer_Phone = table.Column<string>(nullable: true),
                    Customer_Email = table.Column<string>(nullable: true),
                    Calendar_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customers_Calendars_Calendar_Id",
                        column: x => x.Calendar_Id,
                        principalTable: "Calendars",
                        principalColumn: "Calendar_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairDressers",
                columns: table => new
                {
                    Service_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Service_Name = table.Column<string>(nullable: true),
                    Service_Price = table.Column<decimal>(nullable: false),
                    Calendar_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairDressers", x => x.Service_Id);
                    table.ForeignKey(
                        name: "FK_HairDressers_Calendars_Calendar_Id",
                        column: x => x.Calendar_Id,
                        principalTable: "Calendars",
                        principalColumn: "Calendar_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Calendar_Id",
                table: "Customers",
                column: "Calendar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HairDressers_Calendar_Id",
                table: "HairDressers",
                column: "Calendar_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "HairDressers");

            migrationBuilder.DropTable(
                name: "Calendars");
        }
    }
}
