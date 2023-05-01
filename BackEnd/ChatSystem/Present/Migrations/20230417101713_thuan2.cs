using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Present.Migrations
{
    public partial class thuan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualMessages");

            migrationBuilder.CreateTable(
                name: "IndividualChats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserSendId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserReceiveId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualChats_AspNetUsers_UserReceiveId",
                        column: x => x.UserReceiveId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndividualChats_AspNetUsers_UserSendId",
                        column: x => x.UserSendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_IndividualChats_IndividualChatId",
                        column: x => x.IndividualChatId,
                        principalTable: "IndividualChats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IndividualChatId",
                table: "Chats",
                column: "IndividualChatId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualChats_UserReceiveId",
                table: "IndividualChats",
                column: "UserReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualChats_UserSendId",
                table: "IndividualChats",
                column: "UserSendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "IndividualChats");

            migrationBuilder.CreateTable(
                name: "IndividualMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserReceiveId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserSendId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualMessages_AspNetUsers_UserReceiveId",
                        column: x => x.UserReceiveId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndividualMessages_AspNetUsers_UserSendId",
                        column: x => x.UserSendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMessages_UserReceiveId",
                table: "IndividualMessages",
                column: "UserReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMessages_UserSendId",
                table: "IndividualMessages",
                column: "UserSendId");
        }
    }
}
