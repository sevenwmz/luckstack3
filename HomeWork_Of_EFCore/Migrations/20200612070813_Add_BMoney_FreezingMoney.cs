using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class Add_BMoney_FreezingMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreezingMoney",
                table: "BMoneys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreezingMoney",
                table: "BMoneys");
        }
    }
}
