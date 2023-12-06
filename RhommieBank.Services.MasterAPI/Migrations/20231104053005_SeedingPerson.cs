using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhommieBank.Services.MasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "id", "age", "created_by", "created_dt", "name" },
                values: new object[,]
                {
                    { 1, 22, "System", new DateTime(2023, 11, 4, 12, 30, 5, 592, DateTimeKind.Local).AddTicks(7416), "Erling Haaland" },
                    { 2, 24, "System", new DateTime(2023, 11, 4, 12, 30, 5, 592, DateTimeKind.Local).AddTicks(7444), "Kylian Mbappe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
