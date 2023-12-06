using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableRekening_ChangeTypeDateCreated_Dt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_dt",
                table: "Rekening",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 22, 8, 9, 1, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 22, 8, 9, 1, DateTimeKind.Local).AddTicks(8380));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "created_dt",
                table: "Rekening",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 22, 5, 37, 632, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 22, 5, 37, 632, DateTimeKind.Local).AddTicks(5849));
        }
    }
}
