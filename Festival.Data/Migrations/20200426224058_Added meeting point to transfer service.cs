using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class Addedmeetingpointtotransferservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeetingPoint",
                table: "TransferService",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingPoint",
                table: "TransferService");
        }
    }
}
