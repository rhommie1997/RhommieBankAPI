using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCurrency_WithAlterBankFKCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Bank",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyCode);
                });

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "BankCode",
                keyValue: "002",
                column: "CurrencyCode",
                value: "IDR");

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "BankCode",
                keyValue: "008",
                column: "CurrencyCode",
                value: "IDR");

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "BankCode",
                keyValue: "009",
                column: "CurrencyCode",
                value: "IDR");

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "BankCode",
                keyValue: "014",
                column: "CurrencyCode",
                value: "IDR");

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyCode", "Country", "CurrencyName" },
                values: new object[,]
                {
                    { "AUD", "Australia", "Australian Dollar" },
                    { "GBP", "United Kingdom", "Sterling" },
                    { "IDR", "Indonesia", "Indonesian Rupiah" },
                    { "JPY", "Japan", "Japan Yen" },
                    { "MYR", "Malaysia", "Malaysian Ringgit" },
                    { "USD", "United States", "US Dollar" }
                });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 12, 6, 15, 9, 54, 815, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 12, 6, 15, 9, 54, 815, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.CreateIndex(
                name: "IX_Bank_CurrencyCode",
                table: "Bank",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank_Currency_CurrencyCode",
                table: "Bank",
                column: "CurrencyCode",
                principalTable: "Currency",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank_Currency_CurrencyCode",
                table: "Bank");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Bank_CurrencyCode",
                table: "Bank");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Bank");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 12, 6, 14, 24, 16, 578, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 12, 6, 14, 24, 16, 578, DateTimeKind.Local).AddTicks(1836));
        }
    }
}
