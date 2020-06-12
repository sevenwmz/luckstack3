using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class Change_BMoneyOwnerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BMoneys_Register_OwnerName",
                table: "BMoneys");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "BMoneys");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "BMoneys",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AddForeignKey(
                name: "FK_BMoneys_Register_OwnerName",
                table: "BMoneys",
                column: "OwnerName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BMoneys_Register_OwnerName",
                table: "BMoneys");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "BMoneys",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "BMoneys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BMoneys_Register_OwnerName",
                table: "BMoneys",
                column: "OwnerName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
