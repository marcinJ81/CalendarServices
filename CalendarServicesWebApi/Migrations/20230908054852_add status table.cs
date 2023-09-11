using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarServices.Migrations
{
    public partial class addstatustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Calendar_TimeService",
                table: "Calendars",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Ss_id",
                table: "Calendars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusOfTheServices",
                columns: table => new
                {
                    Ss_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ss_Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOfTheServices", x => x.Ss_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_Ss_id",
                table: "Calendars",
                column: "Ss_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_StatusOfTheServices_Ss_id",
                table: "Calendars",
                column: "Ss_id",
                principalTable: "StatusOfTheServices",
                principalColumn: "Ss_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_StatusOfTheServices_Ss_id",
                table: "Calendars");

            migrationBuilder.DropTable(
                name: "StatusOfTheServices");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_Ss_id",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "Calendar_TimeService",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "Ss_id",
                table: "Calendars");
        }
    }
}
