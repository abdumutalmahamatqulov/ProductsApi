using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("a2764599-ece5-4f15-b221-a5a77e87eb76"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), new Guid("8eedbe4f-def8-449c-ab43-08dc731c72ec") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2764599-ece5-4f15-b221-a5a77e87eb76"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), new Guid("8eedbe4f-def8-449c-ab43-08dc731c72ec") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("066ffda9-706f-44c1-8e63-0de63801376d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0641fde5-c1d1-4052-9a48-d03f41bd0503"), null, "ADMIN", "ADMIN" },
                    { new Guid("7ade121c-ae7d-4fbf-8c1d-0ca5022d913a"), null, "SUPERADMIN", "SUPERADMIN" }
                });
        }
    }
}
