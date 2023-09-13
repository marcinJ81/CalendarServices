using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarServices.Migrations
{
    public partial class addnewtabletypeServiceandconnecttohairservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Service_Name",
                table: "HairDressers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "Service_Archival",
                table: "HairDressers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Service_Time",
                table: "HairDressers",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TypeService_Id",
                table: "HairDressers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeServices",
                columns: table => new
                {
                    TypeService_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeService_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeServices", x => x.TypeService_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HairDressers_TypeService_Id",
                table: "HairDressers",
                column: "TypeService_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HairDressers_TypeServices_TypeService_Id",
                table: "HairDressers",
                column: "TypeService_Id",
                principalTable: "TypeServices",
                principalColumn: "TypeService_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairDressers_TypeServices_TypeService_Id",
                table: "HairDressers");

            migrationBuilder.DropTable(
                name: "TypeServices");

            migrationBuilder.DropIndex(
                name: "IX_HairDressers_TypeService_Id",
                table: "HairDressers");

            migrationBuilder.DropColumn(
                name: "Service_Archival",
                table: "HairDressers");

            migrationBuilder.DropColumn(
                name: "Service_Time",
                table: "HairDressers");

            migrationBuilder.DropColumn(
                name: "TypeService_Id",
                table: "HairDressers");

            migrationBuilder.AlterColumn<string>(
                name: "Service_Name",
                table: "HairDressers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
