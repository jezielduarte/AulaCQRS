using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aula.DDD.CQRS.Infra.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ACCOUNT_HOLDER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACCOUNT_HOLDER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    USER_NAME = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    PASS = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ALLOWS_OPEN_ACCOUNT = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ALLOWS_RELEASE_OVERDRAFT = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATE_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    AGENCY = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    NUMBER = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    BALANCE = table.Column<decimal>(type: "decimal", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ACCOUNT_HOLDER_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ACCOUNT_TYPE = table.Column<int>(type: "integer", nullable: false),
                    OVERDRAFT = table.Column<decimal>(type: "decimal", nullable: false),
                    USER_OVERDRAFT_RELEASE = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_ACCOUNT_TB_ACCOUNT_HOLDER_ACCOUNT_HOLDER_ID",
                        column: x => x.ACCOUNT_HOLDER_ID,
                        principalTable: "TB_ACCOUNT_HOLDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRANSACTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    OPERATION = table.Column<int>(type: "int", nullable: false),
                    AMMOUNT = table.Column<decimal>(type: "numeric", nullable: false),
                    DATE = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ACCOUNT_ID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRANSACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACTION_TB_ACCOUNT_ACCOUNT_ID",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "TB_ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ACCOUNT_ACCOUNT_HOLDER_ID",
                table: "TB_ACCOUNT",
                column: "ACCOUNT_HOLDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACTION_ACCOUNT_ID",
                table: "TB_TRANSACTION",
                column: "ACCOUNT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TB_USER");

            migrationBuilder.DropTable(
                name: "TB_ACCOUNT");

            migrationBuilder.DropTable(
                name: "TB_ACCOUNT_HOLDER");
        }
    }
}
