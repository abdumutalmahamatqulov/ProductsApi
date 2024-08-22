using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change_from_FileMetadata_to_FileMetadatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileMetadata",
                table: "FileMetadata");

            migrationBuilder.RenameTable(
                name: "FileMetadata",
                newName: "FileMetadatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileMetadatas",
                table: "FileMetadatas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "86e4701a-cff1-4fe5-a5c1-33da88854f7f");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileMetadatas",
                table: "FileMetadatas");

            migrationBuilder.RenameTable(
                name: "FileMetadatas",
                newName: "FileMetadata");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileMetadata",
                table: "FileMetadata",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "28a22612-421b-4292-a487-c09208c4a880");
        }
    }
}
