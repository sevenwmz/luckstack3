using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class AddUserAndProblem_ForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Problem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problem_AuthorId",
                table: "Problem",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Register_AuthorId",
                table: "Problem",
                column: "AuthorId",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Register_AuthorId",
                table: "Problem");

            migrationBuilder.DropIndex(
                name: "IX_Problem_AuthorId",
                table: "Problem");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Problem");
        }
    }
}
