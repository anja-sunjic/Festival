using Microsoft.EntityFrameworkCore.Migrations;

namespace Festival.Data.Migrations
{
    public partial class UpdatedPerformermodelwithPictureinsteadofimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performer_Image_ImageID",
                table: "Performer");

            migrationBuilder.DropIndex(
                name: "IX_Performer_ImageID",
                table: "Performer");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Performer");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Performer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Performer");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Performer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Performer_ImageID",
                table: "Performer",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Performer_Image_ImageID",
                table: "Performer",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
