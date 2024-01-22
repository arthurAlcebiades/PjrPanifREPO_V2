using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrjPaniMVCv2.Migrations
{
    /// <inheritdoc />
    public partial class Versao6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataInicioRecorrencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataFinalRecorrencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValorTotal = table.Column<double>(type: "double precision", nullable: true),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    EnderecoEntregaLogradouro = table.Column<string>(name: "EnderecoEntrega_Logradouro", type: "text", nullable: false),
                    EnderecoEntregaNumero = table.Column<string>(name: "EnderecoEntrega_Numero", type: "text", nullable: false),
                    EnderecoEntregaComplemento = table.Column<string>(name: "EnderecoEntrega_Complemento", type: "text", nullable: false),
                    EnderecoEntregaBairro = table.Column<string>(name: "EnderecoEntrega_Bairro", type: "text", nullable: false),
                    EnderecoEntregaCidade = table.Column<string>(name: "EnderecoEntrega_Cidade", type: "text", nullable: false),
                    EnderecoEntregaEstado = table.Column<string>(name: "EnderecoEntrega_Estado", type: "char(2)", nullable: false),
                    EnderecoEntregaCEP = table.Column<string>(name: "EnderecoEntrega_CEP", type: "char(9)", nullable: false),
                    EnderecoEntregaReferencia = table.Column<string>(name: "EnderecoEntrega_Referencia", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
