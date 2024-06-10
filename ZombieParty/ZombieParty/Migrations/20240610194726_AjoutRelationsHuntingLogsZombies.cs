using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZombieParty.Migrations
{
    public partial class AjoutRelationsHuntingLogsZombies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HuntingLogZombie",
                columns: table => new
                {
                    HuntingLogsId = table.Column<int>(type: "int", nullable: false),
                    ZombieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingLogZombie", x => new { x.HuntingLogsId, x.ZombieId });
                    table.ForeignKey(
                        name: "FK_HuntingLogZombie_HuntingLog_HuntingLogsId",
                        column: x => x.HuntingLogsId,
                        principalTable: "HuntingLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HuntingLogZombie_Zombie_ZombieId",
                        column: x => x.ZombieId,
                        principalTable: "Zombie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HuntingLogZombie_ZombieId",
                table: "HuntingLogZombie",
                column: "ZombieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuntingLogZombie");
        }
    }
}
