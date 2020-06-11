using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class ChangeTo_1And11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Email_SendToId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_SendToId",
                table: "Register");

            migrationBuilder.AlterColumn<int>(
                name: "SendToId",
                table: "Register",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromWhoId",
                table: "Email",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Register_SendToId",
                table: "Register",
                column: "SendToId",
                unique: true,
                filter: "[SendToId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Email_SendToId",
                table: "Register",
                column: "SendToId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Email_SendToId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_SendToId",
                table: "Register");

            migrationBuilder.AlterColumn<int>(
                name: "SendToId",
                table: "Register",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromWhoId",
                table: "Email",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Register_SendToId",
                table: "Register",
                column: "SendToId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Email_SendToId",
                table: "Register",
                column: "SendToId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
