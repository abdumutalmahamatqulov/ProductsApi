using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FileMetadatas_FileMetadataId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "4d7805a0-d8d8-4faa-aac5-1dcea562fa21");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FileMetadatas_FileMetadataId",
                table: "Products",
                column: "FileMetadataId",
                principalTable: "FileMetadatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FileMetadatas_FileMetadataId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "b2ea5f88-361c-4c5d-958a-7bdb4be1d0cc");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FileMetadatas_FileMetadataId",
                table: "Products",
                column: "FileMetadataId",
                principalTable: "FileMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
