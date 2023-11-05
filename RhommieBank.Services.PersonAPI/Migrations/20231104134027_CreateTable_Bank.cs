using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhommieBank.Services.PersonAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Bank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankCode);
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "BankCode", "BankName" },
                values: new object[,]
                {
                    { "002", "BRI" },
                    { "008", "Bank Mandiri" },
                    { "009", "BNI" },
                    { "014", "BCA" }
                });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 20, 40, 27, 246, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 20, 40, 27, 246, DateTimeKind.Local).AddTicks(8543));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 12, 30, 5, 592, DateTimeKind.Local).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 12, 30, 5, 592, DateTimeKind.Local).AddTicks(7444));
        }
    }
}
