using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NileHotels.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB301 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractRecepitVouchers_Contractss_ContractId",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseItems");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsHospitalityContract",
                table: "Contractss",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contractss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ContractRecepitVouchers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ContractRecepitVouchers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "ContractRecepitVouchers",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "ContractRecepitVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Isprocess",
                table: "ContractRecepitVouchers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentNature",
                table: "ContractRecepitVouchers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ContractRecepitVouchers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalRemainingValue",
                table: "ContractRecepitVouchers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "ContractPaymentVouchers",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "ContractPaymentVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Isprocess",
                table: "ContractPaymentVouchers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentNature",
                table: "ContractPaymentVouchers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "ContractPaymentVouchers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalRemainingValue",
                table: "ContractPaymentVouchers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "SerialNo",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddressAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddressEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VatNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomRecords_Contractss_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contractss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContact_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyContact_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentVouchers_HotelId",
                table: "ContractPaymentVouchers",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                table: "Company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContact_CompanyId",
                table: "CompanyContact",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContact_ContactTypeId",
                table: "CompanyContact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRecords_ContractId",
                table: "RoomRecords",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractPaymentVouchers_Hotels_HotelId",
                table: "ContractPaymentVouchers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRecepitVouchers_Contractss_ContractId",
                table: "ContractRecepitVouchers",
                column: "ContractId",
                principalTable: "Contractss",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractPaymentVouchers_Hotels_HotelId",
                table: "ContractPaymentVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRecepitVouchers_Contractss_ContractId",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropTable(
                name: "CompanyContact");

            migrationBuilder.DropTable(
                name: "RoomRecords");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_ContractPaymentVouchers_HotelId",
                table: "ContractPaymentVouchers");

            migrationBuilder.DropColumn(
                name: "IsHospitalityContract",
                table: "Contractss");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contractss");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropColumn(
                name: "Isprocess",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropColumn(
                name: "PaymentNature",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropColumn(
                name: "TotalRemainingValue",
                table: "ContractRecepitVouchers");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "ContractPaymentVouchers");

            migrationBuilder.DropColumn(
                name: "Isprocess",
                table: "ContractPaymentVouchers");

            migrationBuilder.DropColumn(
                name: "PaymentNature",
                table: "ContractPaymentVouchers");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ContractPaymentVouchers");

            migrationBuilder.DropColumn(
                name: "TotalRemainingValue",
                table: "ContractPaymentVouchers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "NameAr");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceNo",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PurchaseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "ContractRecepitVouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeletedBy",
                table: "ContractRecepitVouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ContractRecepitVouchers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ContractPaymentVouchers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "SerialNo",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRecepitVouchers_Contractss_ContractId",
                table: "ContractRecepitVouchers",
                column: "ContractId",
                principalTable: "Contractss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
