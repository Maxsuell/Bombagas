using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RWorkVendaPecaV6_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_peca_vendaPecas_IdVendaPeca",
                table: "peca");

            migrationBuilder.DropIndex(
                name: "IX_peca_IdVendaPeca",
                table: "peca");

            migrationBuilder.DropColumn(
                name: "IdVendaPeca",
                table: "peca");

            migrationBuilder.DropColumn(
                name: "Qnt",
                table: "peca");

            migrationBuilder.AddColumn<int>(
                name: "IdItemPeca",
                table: "vendaPecas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "peca",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "itemPeca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdVendaPeca = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPeca = table.Column<int>(type: "INTEGER", nullable: false),
                    PecaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Qnt = table.Column<int>(type: "INTEGER", nullable: false),
                    PreUni = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemPeca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemPeca_peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "peca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_itemPeca_vendaPecas_IdVendaPeca",
                        column: x => x.IdVendaPeca,
                        principalTable: "vendaPecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemPeca_IdVendaPeca",
                table: "itemPeca",
                column: "IdVendaPeca");

            migrationBuilder.CreateIndex(
                name: "IX_itemPeca_PecaId",
                table: "itemPeca",
                column: "PecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemPeca");

            migrationBuilder.DropColumn(
                name: "IdItemPeca",
                table: "vendaPecas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "peca");

            migrationBuilder.AddColumn<int>(
                name: "IdVendaPeca",
                table: "peca",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qnt",
                table: "peca",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_peca_IdVendaPeca",
                table: "peca",
                column: "IdVendaPeca");

            migrationBuilder.AddForeignKey(
                name: "FK_peca_vendaPecas_IdVendaPeca",
                table: "peca",
                column: "IdVendaPeca",
                principalTable: "vendaPecas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
