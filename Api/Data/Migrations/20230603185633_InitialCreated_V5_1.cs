using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated_V5_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientApps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: true),
                    NameClient = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    QNTBicos = table.Column<int>(type: "INTEGER", nullable: false),
                    QNTTanques = table.Column<int>(type: "INTEGER", nullable: false),
                    Dividas = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientApps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "peca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamePeca = table.Column<string>(type: "TEXT", nullable: true),
                    ValorUnit = table.Column<float>(type: "REAL", nullable: false),
                    QntEst = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userApps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    ChaveSenha = table.Column<string>(type: "TEXT", nullable: true),
                    Nivel_User = table.Column<int>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userApps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chamados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chamados_clientApps_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contatos_clientApps_IdClient",
                        column: x => x.IdClient,
                        principalTable: "clientApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTecnico = table.Column<int>(type: "nvarchar(20)", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IdPeca = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorServico = table.Column<float>(type: "REAL", nullable: false),
                    DescPagamento = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicos_clientApps_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicos_peca_IdPeca",
                        column: x => x.IdPeca,
                        principalTable: "peca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendaPecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Qnt = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorTotal = table.Column<float>(type: "REAL", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPeca = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendaPecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendaPecas_clientApps_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendaPecas_peca_IdPeca",
                        column: x => x.IdPeca,
                        principalTable: "peca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chamados_IdCliente",
                table: "chamados",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_contatos_IdClient",
                table: "contatos",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_servicos_IdCliente",
                table: "servicos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_servicos_IdPeca",
                table: "servicos",
                column: "IdPeca");

            migrationBuilder.CreateIndex(
                name: "IX_vendaPecas_IdCliente",
                table: "vendaPecas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_vendaPecas_IdPeca",
                table: "vendaPecas",
                column: "IdPeca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamados");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "servicos");

            migrationBuilder.DropTable(
                name: "userApps");

            migrationBuilder.DropTable(
                name: "vendaPecas");

            migrationBuilder.DropTable(
                name: "clientApps");

            migrationBuilder.DropTable(
                name: "peca");
        }
    }
}
