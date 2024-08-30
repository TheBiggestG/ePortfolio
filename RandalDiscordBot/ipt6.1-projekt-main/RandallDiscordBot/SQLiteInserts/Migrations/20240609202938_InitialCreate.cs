using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLiteInserts.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplaintType",
                columns: table => new
                {
                    ComplaintTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComplaintTypeName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintType", x => x.ComplaintTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DiscordServer",
                columns: table => new
                {
                    DiscordServerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscordServerInternalId = table.Column<int>(type: "INT", nullable: true),
                    DiscordServerName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordServer", x => x.DiscordServerId);
                });

            migrationBuilder.CreateTable(
                name: "DiscordUser",
                columns: table => new
                {
                    DiscordUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscordUserInternalId = table.Column<int>(type: "int identity", nullable: true),
                    DiscordUserName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Points = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordUser", x => x.DiscordUserId);
                });

            migrationBuilder.CreateTable(
                name: "LogType",
                columns: table => new
                {
                    LogTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LogTypeName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogType", x => x.LogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserLoginId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserLoginName = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserLoginPassword = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserLoginId);
                });

            migrationBuilder.CreateTable(
                name: "UserIsInServer",
                columns: table => new
                {
                    UserIsInServerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fk_ServerId = table.Column<int>(type: "INT", nullable: true),
                    fk_DiscordUserId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIsInServer", x => x.UserIsInServerId);
                    table.ForeignKey(
                        name: "FK_UserIsInServer_DiscordServer_fk_ServerId",
                        column: x => x.fk_ServerId,
                        principalTable: "DiscordServer",
                        principalColumn: "DiscordServerId");
                    table.ForeignKey(
                        name: "FK_UserIsInServer_DiscordUser_fk_DiscordUserId",
                        column: x => x.fk_DiscordUserId,
                        principalTable: "DiscordUser",
                        principalColumn: "DiscordUserId");
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    UserLogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserLogText = table.Column<string>(type: "varchar(255)", nullable: true),
                    fk_LogTypeId = table.Column<int>(type: "INT", nullable: true),
                    fk_DiscordUserId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.UserLogId);
                    table.ForeignKey(
                        name: "FK_UserLog_DiscordUser_fk_DiscordUserId",
                        column: x => x.fk_DiscordUserId,
                        principalTable: "DiscordUser",
                        principalColumn: "DiscordUserId");
                    table.ForeignKey(
                        name: "FK_UserLog_LogType_fk_LogTypeId",
                        column: x => x.fk_LogTypeId,
                        principalTable: "LogType",
                        principalColumn: "LogTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComplaintText = table.Column<string>(type: "varchar(500)", nullable: true),
                    fk_ComplaintTypeId = table.Column<int>(type: "INT", nullable: true),
                    fk_UserLoginId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ComplaintId);
                    table.ForeignKey(
                        name: "FK_Complaint_ComplaintType_fk_ComplaintTypeId",
                        column: x => x.fk_ComplaintTypeId,
                        principalTable: "ComplaintType",
                        principalColumn: "ComplaintTypeId");
                    table.ForeignKey(
                        name: "FK_Complaint_UserLogin_fk_UserLoginId",
                        column: x => x.fk_UserLoginId,
                        principalTable: "UserLogin",
                        principalColumn: "UserLoginId");
                });

            migrationBuilder.CreateTable(
                name: "UserAccessToServer",
                columns: table => new
                {
                    UserAccessToServerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fk_ServerId = table.Column<int>(type: "INT", nullable: true),
                    fk_UserLoginId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessToServer", x => x.UserAccessToServerId);
                    table.ForeignKey(
                        name: "FK_UserAccessToServer_DiscordServer_fk_ServerId",
                        column: x => x.fk_ServerId,
                        principalTable: "DiscordServer",
                        principalColumn: "DiscordServerId");
                    table.ForeignKey(
                        name: "FK_UserAccessToServer_UserLogin_fk_UserLoginId",
                        column: x => x.fk_UserLoginId,
                        principalTable: "UserLogin",
                        principalColumn: "UserLoginId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_fk_ComplaintTypeId",
                table: "Complaint",
                column: "fk_ComplaintTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_fk_UserLoginId",
                table: "Complaint",
                column: "fk_UserLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessToServer_fk_ServerId",
                table: "UserAccessToServer",
                column: "fk_ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessToServer_fk_UserLoginId",
                table: "UserAccessToServer",
                column: "fk_UserLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIsInServer_fk_DiscordUserId",
                table: "UserIsInServer",
                column: "fk_DiscordUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIsInServer_fk_ServerId",
                table: "UserIsInServer",
                column: "fk_ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_fk_DiscordUserId",
                table: "UserLog",
                column: "fk_DiscordUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_fk_LogTypeId",
                table: "UserLog",
                column: "fk_LogTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "UserAccessToServer");

            migrationBuilder.DropTable(
                name: "UserIsInServer");

            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "ComplaintType");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "DiscordServer");

            migrationBuilder.DropTable(
                name: "DiscordUser");

            migrationBuilder.DropTable(
                name: "LogType");
        }
    }
}
