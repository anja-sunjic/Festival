using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class LoggingExceptionsinDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PromoText",
                table: "Performer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Performer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Performer",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ExceptionLoggers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    RequestId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    RequestPath = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    ActionDescriptor = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLoggers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionLoggers");

            migrationBuilder.AlterColumn<string>(
                name: "PromoText",
                table: "Performer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Performer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Performer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }
    }
}
