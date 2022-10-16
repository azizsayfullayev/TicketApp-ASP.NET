using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.WebApi.Migrations
{
    public partial class datetimechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Tickets",
                newName: "StartTime");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Tickets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventDate",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Tickets",
                newName: "StartDate");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
