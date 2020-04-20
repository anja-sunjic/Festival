using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class RemovedImagefromAccommodation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_Image_ImageID",
                table: "Accommodation");

            migrationBuilder.DropIndex(
                name: "IX_Accommodation_ImageID",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Accommodation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Accommodation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_ImageID",
                table: "Accommodation",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_Image_ImageID",
                table: "Accommodation",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
