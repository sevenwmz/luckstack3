using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class ChangeTo_1And1 : Migration
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromWhoId",
                table: "Email",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Email_SendToId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_SendToId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "FromWhoId",
                table: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "SendToId",
                table: "Register",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Register_SendToId",
                table: "Register",
                column: "SendToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Email_SendToId",
                table: "Register",
                column: "SendToId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
