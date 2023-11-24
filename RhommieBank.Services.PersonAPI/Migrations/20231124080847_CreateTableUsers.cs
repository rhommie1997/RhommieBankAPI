using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhommieBank.Services.PersonAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.username);
                });

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

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "username", "email", "imagePath", "isAdmin", "nickname", "password" },
                values: new object[] { "rhommie", "rhommie.1997@gmail.com", null, true, "Rhommie", "123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

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
    }
}
