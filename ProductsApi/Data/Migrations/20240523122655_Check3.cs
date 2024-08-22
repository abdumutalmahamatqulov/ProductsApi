using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Check3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "4d7805a0-d8d8-4faa-aac5-1dcea562fa21");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "1e0cea47-8145-4118-8a0c-a805d87ad736");
        }
    }
}
