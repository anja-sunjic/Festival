using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class Dataanotationfortransferservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferService_TransferVehicle_TransferVehicleID",
                table: "TransferService");

            migrationBuilder.AlterColumn<int>(
                name: "TransferVehicleID",
                table: "TransferService",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingPoint",
                table: "TransferService",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferService_TransferVehicle_TransferVehicleID",
                table: "TransferService",
                column: "TransferVehicleID",
                principalTable: "TransferVehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferService_TransferVehicle_TransferVehicleID",
                table: "TransferService");

            migrationBuilder.AlterColumn<int>(
                name: "TransferVehicleID",
                table: "TransferService",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MeetingPoint",
                table: "TransferService",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferService_TransferVehicle_TransferVehicleID",
                table: "TransferService",
                column: "TransferVehicleID",
                principalTable: "TransferVehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
