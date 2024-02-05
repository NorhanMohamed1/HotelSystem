using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NileHotels.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAssets_Hotels_HotelId",
                table: "RoomAssets");

            migrationBuilder.DropIndex(
                name: "IX_RoomAssets_HotelId",
                table: "RoomAssets");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomAssets");

            migrationBuilder.DropColumn(
                name: "Nationality_CountryId",
                table: "Employees");

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "TaxTypes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "TaxTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "RoomAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nationality_CountryId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAssets_HotelId",
                table: "RoomAssets",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAssets_Hotels_HotelId",
                table: "RoomAssets",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
