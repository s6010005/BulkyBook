using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBook.DataAccess.Migrations
{
    public partial class AddAvailabilityToProductBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailabilityId",
                table: "ProductBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBooks_AvailabilityId",
                table: "ProductBooks",
                column: "AvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBooks_AvailabilityTypes_AvailabilityId",
                table: "ProductBooks",
                column: "AvailabilityId",
                principalTable: "AvailabilityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBooks_AvailabilityTypes_AvailabilityId",
                table: "ProductBooks");

            migrationBuilder.DropIndex(
                name: "IX_ProductBooks_AvailabilityId",
                table: "ProductBooks");

            migrationBuilder.DropColumn(
                name: "AvailabilityId",
                table: "ProductBooks");
        }
    }
}
