using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTransactionNoteAndTransactionType_AndAlterRekeningAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "UserLogins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDefault",
                table: "Rekening",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Charges = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionNote",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rekeningTransferFrom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rekeningTransferTo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    transactionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionTypeID = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    totalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionNote", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionNote_Rekening_rekeningTransferFrom",
                        column: x => x.rekeningTransferFrom,
                        principalTable: "Rekening",
                        principalColumn: "no_rekening",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionNote_Rekening_rekeningTransferTo",
                        column: x => x.rekeningTransferTo,
                        principalTable: "Rekening",
                        principalColumn: "no_rekening",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionNote_TransactionTypes_transactionTypeID",
                        column: x => x.transactionTypeID,
                        principalTable: "TransactionTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "id", "Charges", "TransactionTypeName" },
                values: new object[,]
                {
                    { 1, 0m, "In-House" },
                    { 2, 7000m, "Domestic" },
                    { 3, 45000m, "International" }
                });

            migrationBuilder.UpdateData(
                table: "UserLogins",
                keyColumn: "username",
                keyValue: "rhommie",
                column: "PersonID",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNote_rekeningTransferFrom",
                table: "TransactionNote",
                column: "rekeningTransferFrom");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNote_rekeningTransferTo",
                table: "TransactionNote",
                column: "rekeningTransferTo");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNote_transactionTypeID",
                table: "TransactionNote",
                column: "transactionTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionNote");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "isDefault",
                table: "Rekening");

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
    }
}
