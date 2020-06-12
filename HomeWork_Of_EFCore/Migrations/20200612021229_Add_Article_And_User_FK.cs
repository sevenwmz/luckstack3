using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class Add_Article_And_User_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BMoney_Register_OwnerName",
                table: "BMoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BMoney",
                table: "BMoney");

            migrationBuilder.RenameTable(
                name: "BMoney",
                newName: "BMoneys");

            migrationBuilder.RenameIndex(
                name: "IX_BMoney_OwnerName",
                table: "BMoneys",
                newName: "IX_BMoneys_OwnerName");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BMoneys",
                table: "BMoneys",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Register_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BMoneys_Register_OwnerName",
                table: "BMoneys",
                column: "OwnerName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Register_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_BMoneys_Register_OwnerName",
                table: "BMoneys");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BMoneys",
                table: "BMoneys");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "BMoneys",
                newName: "BMoney");

            migrationBuilder.RenameIndex(
                name: "IX_BMoneys_OwnerName",
                table: "BMoney",
                newName: "IX_BMoney_OwnerName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BMoney",
                table: "BMoney",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BMoney_Register_OwnerName",
                table: "BMoney",
                column: "OwnerName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
