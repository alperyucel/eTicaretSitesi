using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlisverisLab.DataAccess.Migrations.AlisverisLabLOGDb
{
    /// <inheritdoc />
    public partial class addDateTimeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(925), new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(929), new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(931), new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(931) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(933), new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "LogTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(935), new DateTime(2025, 5, 13, 18, 49, 45, 959, DateTimeKind.Local).AddTicks(935) });
        }
    }
}
