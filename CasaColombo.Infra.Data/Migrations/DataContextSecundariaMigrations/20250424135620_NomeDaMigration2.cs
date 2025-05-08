using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaColombo.Infra.Data.Migrations.DataContextSecundariaMigrations
{
    /// <inheritdoc />
    public partial class NomeDaMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENTREGA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: false),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    VALOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGEMURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIASEMANA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VENDEDOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERIODO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MOTORISTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAVENDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MOTORISTAATUAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOIDATUALIZADOR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTREGA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ESCALA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IMAGEMURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESCALA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TITULORECEBER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: false),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VALOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDEDOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGEMURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAVENDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIOIDATUALIZADOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAPREVPG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TITULORECEBER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TITULORECEBERFUNCIONARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: false),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VALOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDEDOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGEMURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAVENDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIOIDATUALIZADOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAPREVPG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TITULORECEBERFUNCIONARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BAIXAENTREGA",
                columns: table => new
                {
                    IDBAIXAENTREGA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTREGAID = table.Column<int>(type: "int", nullable: false),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: true),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    VALORNOTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLIMAGEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIASEMANA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDEDOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERIODO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAVENDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTORISTAATUAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTORISTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntregaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAIXAENTREGA", x => x.IDBAIXAENTREGA);
                    table.ForeignKey(
                        name: "FK_BAIXAENTREGA_ENTREGA_ENTREGAID",
                        column: x => x.ENTREGAID,
                        principalTable: "ENTREGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BAIXAENTREGA_ENTREGA_EntregaId1",
                        column: x => x.EntregaId1,
                        principalTable: "ENTREGA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "IMPRESSAO",
                columns: table => new
                {
                    IDIMPRESSAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTREGAID = table.Column<int>(type: "int", nullable: false),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: false),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntregaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPRESSAO", x => x.IDIMPRESSAO);
                    table.ForeignKey(
                        name: "FK_IMPRESSAO_ENTREGA_ENTREGAID",
                        column: x => x.ENTREGAID,
                        principalTable: "ENTREGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IMPRESSAO_ENTREGA_EntregaId1",
                        column: x => x.EntregaId1,
                        principalTable: "ENTREGA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                columns: table => new
                {
                    IDPAGAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTREGAID = table.Column<int>(type: "int", nullable: false),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: false),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUSDEPAGAMENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntregaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.IDPAGAMENTO);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_ENTREGA_ENTREGAID",
                        column: x => x.ENTREGAID,
                        principalTable: "ENTREGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_ENTREGA_EntregaId1",
                        column: x => x.EntregaId1,
                        principalTable: "ENTREGA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PENDENCIAENTREGA",
                columns: table => new
                {
                    IDPENDENCIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTREGAID = table.Column<int>(type: "int", nullable: false),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: true),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    VALORNOTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLIMAGEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OBSERVACAOPENDENCIA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDEDOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERIODO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAVENDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIASEMANA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTORISTAATUAL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTORISTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIASEMANAPENDENCIA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROXIMAENTREGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntregaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PENDENCIAENTREGA", x => x.IDPENDENCIA);
                    table.ForeignKey(
                        name: "FK_PENDENCIAENTREGA_ENTREGA_ENTREGAID",
                        column: x => x.ENTREGAID,
                        principalTable: "ENTREGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PENDENCIAENTREGA_ENTREGA_EntregaId1",
                        column: x => x.EntregaId1,
                        principalTable: "ENTREGA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BAIXAETITULORECEBER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTREGAID = table.Column<int>(type: "int", nullable: false),
                    NUMERONOTA = table.Column<int>(type: "int", nullable: true),
                    NOMECLIENTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VALORNOTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VENDEDOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOJA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIOID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLIMAGEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAVENDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAPREVPG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TituloReceberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAIXAETITULORECEBER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BAIXAETITULORECEBER_TITULORECEBER_ENTREGAID",
                        column: x => x.ENTREGAID,
                        principalTable: "TITULORECEBER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BAIXAETITULORECEBER_TITULORECEBER_TituloReceberId",
                        column: x => x.TituloReceberId,
                        principalTable: "TITULORECEBER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BaixaTituloFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloId = table.Column<int>(type: "int", nullable: false),
                    NumeroNota = table.Column<int>(type: "int", nullable: true),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVenda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPrevistaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TituloReceberFuncionarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaixaTituloFuncionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaixaTituloFuncionario_TITULORECEBERFUNCIONARIO_TituloReceberFuncionarioId",
                        column: x => x.TituloReceberFuncionarioId,
                        principalTable: "TITULORECEBERFUNCIONARIO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAIXAENTREGA_ENTREGAID",
                table: "BAIXAENTREGA",
                column: "ENTREGAID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXAENTREGA_EntregaId1",
                table: "BAIXAENTREGA",
                column: "EntregaId1");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXAETITULORECEBER_ENTREGAID",
                table: "BAIXAETITULORECEBER",
                column: "ENTREGAID");

            migrationBuilder.CreateIndex(
                name: "IX_BAIXAETITULORECEBER_TituloReceberId",
                table: "BAIXAETITULORECEBER",
                column: "TituloReceberId");

            migrationBuilder.CreateIndex(
                name: "IX_BaixaTituloFuncionario_TituloReceberFuncionarioId",
                table: "BaixaTituloFuncionario",
                column: "TituloReceberFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_IMPRESSAO_ENTREGAID",
                table: "IMPRESSAO",
                column: "ENTREGAID");

            migrationBuilder.CreateIndex(
                name: "IX_IMPRESSAO_EntregaId1",
                table: "IMPRESSAO",
                column: "EntregaId1");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_ENTREGAID",
                table: "PAGAMENTO",
                column: "ENTREGAID");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_EntregaId1",
                table: "PAGAMENTO",
                column: "EntregaId1");

            migrationBuilder.CreateIndex(
                name: "IX_PENDENCIAENTREGA_ENTREGAID",
                table: "PENDENCIAENTREGA",
                column: "ENTREGAID");

            migrationBuilder.CreateIndex(
                name: "IX_PENDENCIAENTREGA_EntregaId1",
                table: "PENDENCIAENTREGA",
                column: "EntregaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BAIXAENTREGA");

            migrationBuilder.DropTable(
                name: "BAIXAETITULORECEBER");

            migrationBuilder.DropTable(
                name: "BaixaTituloFuncionario");

            migrationBuilder.DropTable(
                name: "ESCALA");

            migrationBuilder.DropTable(
                name: "IMPRESSAO");

            migrationBuilder.DropTable(
                name: "PAGAMENTO");

            migrationBuilder.DropTable(
                name: "PENDENCIAENTREGA");

            migrationBuilder.DropTable(
                name: "TITULORECEBER");

            migrationBuilder.DropTable(
                name: "TITULORECEBERFUNCIONARIO");

            migrationBuilder.DropTable(
                name: "ENTREGA");
        }
    }
}
