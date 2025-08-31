using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlisverisLab.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMenuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ActionName", "Active", "AreaName", "ControllerName", "CreatedTime", "Icon", "Title", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, "Index", true, "admin", "Home", new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5598), "nav-icon fas fa-tachometer-alt", "Dashboard", new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5607) },
                    { 2, "Index", true, "admin", "Product", new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5611), "nav-icon fas fa-th", "Products", new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5611) },
                    { 3, "Index", true, "admin", "Category", new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5613), "nav-icon fas fa-th", "Categories", new DateTime(2025, 6, 29, 2, 0, 55, 278, DateTimeKind.Local).AddTicks(5613) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "52302917-d3c2-451d-a815-eda29bfb6d55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e084cd2c-0a42-42b7-be3a-7e8a45fa6a84");
        }
    }
}
