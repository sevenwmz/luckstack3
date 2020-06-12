using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class Add_BMoney_LatesTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LatesTime",
                table: "BMoneys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatesTime",
                table: "BMoneys");
        }
    }
}
