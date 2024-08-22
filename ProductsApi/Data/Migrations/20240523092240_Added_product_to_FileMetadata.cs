using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_product_to_FileMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FileMetadataId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "dd501a76-b31b-4bc8-acc0-a843d36b8e77");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FileMetadataId",
                table: "Products",
                column: "FileMetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FileMetadatas_FileMetadataId",
                table: "Products",
                column: "FileMetadataId",
                principalTable: "FileMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FileMetadatas_FileMetadataId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FileMetadataId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FileMetadataId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cde79a12-0364-4df7-ac73-9b9fb0a41745"),
                column: "ConcurrencyStamp",
                value: "86e4701a-cff1-4fe5-a5c1-33da88854f7f");
        }
    }
}
