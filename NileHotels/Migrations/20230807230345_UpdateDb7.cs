using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NileHotels.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "ServiceItems");

            migrationBuilder.DropColumn(
                name: "NameEr",
                table: "ServiceItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ServiceItems");

            migrationBuilder.RenameColumn(
                name: "FullAddress",
                table: "Hotels",
                newName: "gps");

            migrationBuilder.RenameColumn(
                name: "Nationality_CountryId",
                table: "Customers",
                newName: "HotelId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResponsableName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VatNo",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "TaxTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Vat",
                table: "Services",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullAddressAr",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullAddressEn",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdValue",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsShare",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CityId",
                table: "Vendors",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypes_HotelId",
                table: "TaxTypes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CustomerId",
                table: "Services",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_StoreId",
                table: "Services",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_HotelId",
                table: "Customers",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_HotelId",
                table: "Asset",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Hotels_HotelId",
                table: "Asset",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Customers_CustomerId",
                table: "Services",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Stores_StoreId",
                table: "Services",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxTypes_Hotels_HotelId",
                table: "TaxTypes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Country_CityId",
                table: "Vendors",
                column: "CityId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Hotels_HotelId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Customers_CustomerId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Stores_StoreId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxTypes_Hotels_HotelId",
                table: "TaxTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Country_CityId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_CityId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_TaxTypes_HotelId",
                table: "TaxTypes");

            migrationBuilder.DropIndex(
                name: "IX_Services_CustomerId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_StoreId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Customers_HotelId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Asset_HotelId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ResponsableName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VatNo",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "TaxTypes");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FullAddressAr",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "FullAddressEn",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "IdValue",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsShare",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Asset");

            migrationBuilder.RenameColumn(
                name: "gps",
                table: "Hotels",
                newName: "FullAddress");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Customers",
                newName: "Nationality_CountryId");

            migrationBuilder.AlterColumn<string>(
                name: "Vat",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "ServiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEr",
                table: "ServiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ServiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
