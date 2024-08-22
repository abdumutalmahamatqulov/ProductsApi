using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Default_usesr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "883f9786-204b-4e51-9447-f70e947c723a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "cb446629-b625-4cf5-8d03-9906631ff019");
        }
    }
}
