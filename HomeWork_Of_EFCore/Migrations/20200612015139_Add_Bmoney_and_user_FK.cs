using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class Add_Bmoney_and_user_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Kind_HaveKindId",
                table: "Problem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kind",
                table: "Kind");

            migrationBuilder.RenameTable(
                name: "Kind",
                newName: "Kinds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kinds",
                table: "Kinds",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BMoney",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftBMoney = table.Column<int>(nullable: false),
                    LeftBPoint = table.Column<int>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BMoney_Register_OwnerName",
                        column: x => x.OwnerName,
                        principalTable: "Register",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BMoney_OwnerName",
                table: "BMoney",
                column: "OwnerName");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Kinds_HaveKindId",
                table: "Problem",
                column: "HaveKindId",
                principalTable: "Kinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Kinds_HaveKindId",
                table: "Problem");

            migrationBuilder.DropTable(
                name: "BMoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kinds",
                table: "Kinds");

            migrationBuilder.RenameTable(
                name: "Kinds",
                newName: "Kind");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kind",
                table: "Kind",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Kind_HaveKindId",
                table: "Problem",
                column: "HaveKindId",
                principalTable: "Kind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
