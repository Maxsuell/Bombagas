using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RWorkInVendaPeca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendaPecas_peca_IdPeca",
                table: "vendaPecas");

            migrationBuilder.DropIndex(
                name: "IX_vendaPecas_IdPeca",
                table: "vendaPecas");

            migrationBuilder.DropColumn(
                name: "IdPeca",
                table: "vendaPecas");

            migrationBuilder.DropColumn(
                name: "Qnt",
                table: "vendaPecas");

            migrationBuilder.RenameColumn(
                name: "QntEst",
                table: "peca",
                newName: "Qnt");

            migrationBuilder.AddColumn<int>(
                name: "IdVendaPeca",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Qnt",
                table: "peca",
                newName: "QntEst");

            migrationBuilder.AddColumn<int>(
                name: "IdPeca",
                table: "vendaPecas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qnt",
                table: "vendaPecas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vendaPecas_IdPeca",
                table: "vendaPecas",
                column: "IdPeca");

            migrationBuilder.AddForeignKey(
                name: "FK_vendaPecas_peca_IdPeca",
                table: "vendaPecas",
                column: "IdPeca",
                principalTable: "peca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
