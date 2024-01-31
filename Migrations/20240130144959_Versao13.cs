using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrjPaniMVCv2.Migrations
{
    /// <inheritdoc />
    public partial class Versao13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Pedido_PedidoModelIdPedido",
                table: "Motorista");

            migrationBuilder.RenameColumn(
                name: "PedidoModelIdPedido",
                table: "Motorista",
                newName: "PedidoIdPedido");

            migrationBuilder.RenameIndex(
                name: "IX_Motorista_PedidoModelIdPedido",
                table: "Motorista",
                newName: "IX_Motorista_PedidoIdPedido");

            migrationBuilder.AddColumn<int>(
                name: "IdPedido",
                table: "Motorista",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MotoristasPedidos",
                columns: table => new
                {
                    IdMotorista = table.Column<int>(type: "integer", nullable: false),
                    IdPedido = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoristasPedidos", x => new { x.IdPedido, x.IdMotorista });
                    table.ForeignKey(
                        name: "FK_MotoristasPedidos_Motorista_IdMotorista",
                        column: x => x.IdMotorista,
                        principalTable: "Motorista",
                        principalColumn: "IdMotorista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoristasPedidos_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotoristasPedidos_IdMotorista",
                table: "MotoristasPedidos",
                column: "IdMotorista");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Pedido_PedidoIdPedido",
                table: "Motorista",
                column: "PedidoIdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Pedido_PedidoIdPedido",
                table: "Motorista");

            migrationBuilder.DropTable(
                name: "MotoristasPedidos");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Motorista");

            migrationBuilder.RenameColumn(
                name: "PedidoIdPedido",
                table: "Motorista",
                newName: "PedidoModelIdPedido");

            migrationBuilder.RenameIndex(
                name: "IX_Motorista_PedidoIdPedido",
                table: "Motorista",
                newName: "IX_Motorista_PedidoModelIdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Pedido_PedidoModelIdPedido",
                table: "Motorista",
                column: "PedidoModelIdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido");
        }
    }
}
