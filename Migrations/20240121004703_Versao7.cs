using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrjPaniMVCv2.Migrations
{
    /// <inheritdoc />
    public partial class Versao7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Pedido",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Pedido");
        }
    }
}
