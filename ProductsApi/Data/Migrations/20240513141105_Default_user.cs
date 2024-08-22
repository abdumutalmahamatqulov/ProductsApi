using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Default_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"), 0, "cb446629-b625-4cf5-8d03-9906631ff019", "oybek@gmail.com", true, false, null, "OYBEK@GMAIL.COM", "OYBEK", "AQAAAAIAAYagAAAAEFO6ftiV/u05Xiv1Lorpej0W6LEmFqXnGUKSe6VaVecjWdxevE/+3Rn0o/QwxZOXfQ==", null, false, null, false, "Oybek" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"));
        }
    }
}
