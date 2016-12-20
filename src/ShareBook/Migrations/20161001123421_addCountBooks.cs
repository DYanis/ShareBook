using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareBook.Migrations
{
    public partial class addCountBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersBook",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersBook");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Books");
        }
    }
}
