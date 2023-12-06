using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTableTransactionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionNote_TransactionTypes_transactionTypeID",
                table: "TransactionNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionNote_TransactionType_transactionTypeID",
                table: "TransactionNote",
                column: "transactionTypeID",
                principalTable: "TransactionType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionNote_TransactionType_transactionTypeID",
                table: "TransactionNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionType",
                table: "TransactionType");

            migrationBuilder.RenameTable(
                name: "TransactionType",
                newName: "TransactionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2023, 12, 6, 14, 21, 47, 587, DateTimeKind.Local).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2,
                column: "created_dt",
                value: new DateTime(2023, 12, 6, 14, 21, 47, 587, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionNote_TransactionTypes_transactionTypeID",
                table: "TransactionNote",
                column: "transactionTypeID",
                principalTable: "TransactionTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
