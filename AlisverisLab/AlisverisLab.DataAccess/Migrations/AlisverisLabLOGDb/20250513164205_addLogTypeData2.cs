using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlisverisLab.DataAccess.Migrations.AlisverisLabLOGDb
{
    /// <inheritdoc />
    public partial class addLogTypeData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7628), new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7629) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7631), new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7633), new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7635), new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7636), new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7637) });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "Active", "CreatedTime", "LogTypeName", "UpdatedTime" },
                values: new object[,]
                {
                    { 6, true, new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7638), "Non Validation", new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7639) },
                    { 7, true, new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7640), "Not Found", new DateTime(2025, 5, 13, 19, 42, 5, 359, DateTimeKind.Local).AddTicks(7640) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9134), new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9135) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9137), new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9139), new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9141), new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9143), new DateTime(2025, 5, 13, 18, 57, 58, 397, DateTimeKind.Local).AddTicks(9143) });
        }
    }
}
