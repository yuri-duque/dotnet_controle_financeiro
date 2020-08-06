using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users_wallets");

            migrationBuilder.AddColumn<long>(
                name: "IdUser",
                table: "wallets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_wallets_IdUser",
                table: "wallets",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_wallets_usuarios_IdUser",
                table: "wallets",
                column: "IdUser",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wallets_usuarios_IdUser",
                table: "wallets");

            migrationBuilder.DropIndex(
                name: "IX_wallets_IdUser",
                table: "wallets");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "wallets");

            migrationBuilder.CreateTable(
                name: "users_wallets",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdWallet = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_wallets", x => new { x.IdUser, x.IdWallet });
                    table.ForeignKey(
                        name: "FK_users_wallets_usuarios_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_wallets_wallets_IdWallet",
                        column: x => x.IdWallet,
                        principalTable: "wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_wallets_IdWallet",
                table: "users_wallets",
                column: "IdWallet");
        }
    }
}
