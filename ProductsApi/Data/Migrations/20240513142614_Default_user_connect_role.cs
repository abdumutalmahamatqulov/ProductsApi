using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Default_user_connect_role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), new Guid("8eedbe4f-def8-449c-ab43-08dc731c72ec") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "5a387cc3-a85b-46d3-8b71-7ad49dbd5a16");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("066ffda9-706f-44c1-8e63-0de63801376d"), new Guid("8eedbe4f-def8-449c-ab43-08dc731c72ec") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "883f9786-204b-4e51-9447-f70e947c723a");
        }
    }
}
