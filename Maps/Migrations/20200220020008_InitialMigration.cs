using Microsoft.EntityFrameworkCore.Migrations;

namespace Maps.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Origem = table.Column<int>(nullable: false),
                    Destino = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rotas_Pontos_Destino",
                        column: x => x.Destino,
                        principalTable: "Pontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rotas_Pontos_Origem",
                        column: x => x.Origem,
                        principalTable: "Pontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rota = table.Column<int>(nullable: false),
                    Ponto = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paradas_Pontos_Ponto",
                        column: x => x.Ponto,
                        principalTable: "Pontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paradas_Rotas_Rota",
                        column: x => x.Rota,
                        principalTable: "Rotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_Ponto",
                table: "Paradas",
                column: "Ponto");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_Rota",
                table: "Paradas",
                column: "Rota");

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_Destino",
                table: "Rotas",
                column: "Destino");

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_Origem",
                table: "Rotas",
                column: "Origem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paradas");

            migrationBuilder.DropTable(
                name: "Rotas");

            migrationBuilder.DropTable(
                name: "Pontos");
        }
    }
}
