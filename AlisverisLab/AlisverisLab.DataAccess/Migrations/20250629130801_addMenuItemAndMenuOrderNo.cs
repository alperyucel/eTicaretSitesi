using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlisverisLab.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMenuItemAndMenuOrderNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a2b0d683-18cb-4ae5-9939-755c70adbe44");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9190ed0a-43e5-47a9-81ca-4526d86d5f94");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "OrderNumber", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2073), 1, new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2088) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "OrderNumber", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2092), 2, new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "OrderNumber", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2094), 3, new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ActionName", "Active", "AreaName", "ControllerName", "CreatedTime", "Icon", "OrderNumber", "Title", "UpdatedTime" },
                values: new object[] { 4, "Index", true, "admin", "Menu", new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2097), "nav-icon fas fa-th", 4, "Menu Management", new DateTime(2025, 6, 29, 16, 8, 0, 752, DateTimeKind.Local).AddTicks(2098) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d025c747-b6cf-4358-8b7a-192fe16a3959");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "06e606eb-6ef2-4910-96e2-7cb53660cb40");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5598), new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5611), new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5611) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "UpdatedTime" },
                values: new object[] { new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5613), new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5613) });
        }
    }
}
