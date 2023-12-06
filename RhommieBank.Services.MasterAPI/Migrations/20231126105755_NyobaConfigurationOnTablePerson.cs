using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class NyobaConfigurationOnTablePerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Persons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 26, 17, 57, 54, 908, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 26, 17, 57, 54, 908, DateTimeKind.Local).AddTicks(4075));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 24, 15, 8, 47, 372, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 24, 15, 8, 47, 372, DateTimeKind.Local).AddTicks(4514));
        }
    }
}
