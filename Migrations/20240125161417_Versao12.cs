using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrjPaniMVCv2.Migrations
{
    /// <inheritdoc />
    public partial class Versao12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMotorista",
                table: "Pedido",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApelidoRota",
                table: "Motorista",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PedidoModelIdPedido",
                table: "Motorista",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Turno",
                table: "Motorista",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdMotorista",
                table: "Pedido",
                column: "IdMotorista");

            migrationBuilder.CreateIndex(
                name: "IX_Motorista_PedidoModelIdPedido",
                table: "Motorista",
                column: "PedidoModelIdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Pedido_PedidoModelIdPedido",
                table: "Motorista",
                column: "PedidoModelIdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Motorista_IdMotorista",
                table: "Pedido",
                column: "IdMotorista",
                principalTable: "Motorista",
                principalColumn: "IdMotorista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Pedido_PedidoModelIdPedido",
                table: "Motorista");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Motorista_IdMotorista",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdMotorista",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Motorista_PedidoModelIdPedido",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "IdMotorista",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ApelidoRota",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "PedidoModelIdPedido",
                table: "Motorista");

            migrationBuilder.DropColumn(
                name: "Turno",
                table: "Motorista");
        }
    }
}
