using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlisverisLab.DataAccess.Migrations.AlisverisLabLOGDb
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogTypeId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_LogTypes_LogTypeId",
                        column: x => x.LogTypeId,
                        principalTable: "LogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "Active", "CreatedTime", "LogTypeName", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(925), "Insert", new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(926) },
                    { 2, true, new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(929), "Update", new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(929) },
                    { 3, true, new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(931), "Delete", new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(931) },
                    { 4, true, new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(933), "Error", new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(933) },
                    { 5, true, new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(935), "Warning", new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(935) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogTypeId",
                table: "Logs",
                column: "LogTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes");
        }
    }
}
