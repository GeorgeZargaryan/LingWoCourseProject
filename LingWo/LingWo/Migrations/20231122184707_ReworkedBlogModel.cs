using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingWo.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedBlogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogAuthor",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BlogDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BlogLink",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogAuthor",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogLink",
                table: "Blogs");
        }
    }
}
