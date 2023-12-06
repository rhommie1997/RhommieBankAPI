using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTable_RekeningWithRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rekening",
                columns: table => new
                {
                    no_rekening = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isAccres = table.Column<bool>(type: "bit", nullable: false),
                    created_dt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekening", x => x.no_rekening);
                    table.ForeignKey(
                        name: "FK_Rekening_Bank_BankCode",
                        column: x => x.BankCode,
                        principalTable: "Bank",
                        principalColumn: "BankCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rekening_Persons_person_id",
                        column: x => x.person_id,
                        principalTable: "Persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Rekening_BankCode",
                table: "Rekening",
                column: "BankCode");

            migrationBuilder.CreateIndex(
                name: "IX_Rekening_person_id",
                table: "Rekening",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rekening");

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
    }
}
