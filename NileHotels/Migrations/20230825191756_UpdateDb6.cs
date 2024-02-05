using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NileHotels.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractss_FutureReservisions_FutureReservisionId",
                table: "Contractss");

            migrationBuilder.DropIndex(
                name: "IX_Contractss_FutureReservisionId",
                table: "Contractss");

            migrationBuilder.DropColumn(
                name: "FutureReservisionId",
                table: "Contractss");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "NameAr");

            migrationBuilder.AddColumn<float>(
                name: "MinPriceWithBreakfast",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinPriceWithDinner",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinPriceWithLunch",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PriceWithBreakfast",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PriceWithDinner",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PriceWithLunch",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Contractnum",
                table: "FutureReservisions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinPriceWithBreakfast",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MinPriceWithDinner",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MinPriceWithLunch",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PriceWithBreakfast",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PriceWithDinner",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PriceWithLunch",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Contractnum",
                table: "FutureReservisions");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "FutureReservisionId",
                table: "Contractss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contractss_FutureReservisionId",
                table: "Contractss",
                column: "FutureReservisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractss_FutureReservisions_FutureReservisionId",
                table: "Contractss",
                column: "FutureReservisionId",
                principalTable: "FutureReservisions",
                principalColumn: "Id");
        }
    }
}
