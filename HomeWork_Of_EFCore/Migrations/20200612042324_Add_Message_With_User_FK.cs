using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork_Of_EFCore.Migrations
{
    public partial class Add_Message_With_User_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    HasRead = table.Column<bool>(nullable: false),
                    HasCheck = table.Column<bool>(nullable: false),
                    MessageStatus = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Register_OwnerName",
                        column: x => x.OwnerName,
                        principalTable: "Register",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OwnerName",
                table: "Messages",
                column: "OwnerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
