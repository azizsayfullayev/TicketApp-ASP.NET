using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.WebApi.Migrations
{
    public partial class yesSir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Tickets");
        }
    }
}
