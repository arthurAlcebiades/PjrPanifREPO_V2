using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrjPaniMVCv2.Migrations
{
    /// <inheritdoc />
    public partial class Versao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteModelIdUsuario",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ClienteModelIdUsuario",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Endereco",
                newName: "IdUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "Endereco",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Endereco",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                columns: new[] { "IdUsuario", "IdEndereco" });

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_IdUsuario",
                table: "Endereco",
                column: "IdUsuario",
                principalTable: "Cliente",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_IdUsuario",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Endereco",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "Endereco",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Endereco",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ClienteModelIdUsuario",
                table: "Endereco",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                columns: new[] { "ClienteModelIdUsuario", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteModelIdUsuario",
                table: "Endereco",
                column: "ClienteModelIdUsuario",
                principalTable: "Cliente",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
