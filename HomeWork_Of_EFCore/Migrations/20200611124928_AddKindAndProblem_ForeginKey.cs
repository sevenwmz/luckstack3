using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class AddKindAndProblem_ForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HaveKindId",
                table: "Problem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kind", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problem_HaveKindId",
                table: "Problem",
                column: "HaveKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Kind_HaveKindId",
                table: "Problem",
                column: "HaveKindId",
                principalTable: "Kind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Kind_HaveKindId",
                table: "Problem");

            migrationBuilder.DropTable(
                name: "Kind");

            migrationBuilder.DropIndex(
                name: "IX_Problem_HaveKindId",
                table: "Problem");

            migrationBuilder.DropColumn(
                name: "HaveKindId",
                table: "Problem");
        }
    }
}
