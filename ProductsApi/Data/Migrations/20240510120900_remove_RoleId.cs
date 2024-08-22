using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_RoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0dbbd6c0-8548-4b18-afdb-f72db9487f59"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("402e5ac5-bd6b-4b17-98aa-66e88a92fe3a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0641fde5-c1d1-4052-9a48-d03f41bd0503"), null, "ADMIN", "ADMIN" },
                    { new Guid("7ade121c-ae7d-4fbf-8c1d-0ca5022d913a"), null, "SUPERADMIN", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0641fde5-c1d1-4052-9a48-d03f41bd0503"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ade121c-ae7d-4fbf-8c1d-0ca5022d913a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0dbbd6c0-8548-4b18-afdb-f72db9487f59"), null, "ADMIN", "ADMIN" },
                    { new Guid("402e5ac5-bd6b-4b17-98aa-66e88a92fe3a"), null, "SUPERADMIN", "SUPERADMIN" }
                });
        }
    }
}
