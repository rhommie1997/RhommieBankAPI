using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableRekening_ChangeColumnNameisAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAccres",
                table: "Rekening",
                newName: "isAccess");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAccess",
                table: "Rekening",
                newName: "isAccres");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 21, 27, 37, 178, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 11, 4, 21, 27, 37, 178, DateTimeKind.Local).AddTicks(6589));
        }
    }
}
