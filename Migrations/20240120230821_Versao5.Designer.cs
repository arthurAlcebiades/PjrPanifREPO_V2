﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrjPaniMVCv2.Models;

#nullable disable

namespace PrjPaniMVCv2.Migrations
{
    [DbContext(typeof(PaniContext))]
    [Migration("20240120230821_Versao5")]
    partial class Versao5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PrjPaniMVCv2.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("CPF_CNPJ")
                        .IsRequired()
                        .HasColumnType("char(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("TelefoneContatoCliente")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PrjPaniMVCv2.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduto"));

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.Property<string>("TipoUnidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("PrjPaniMVCv2.Models.ClienteModel", b =>
                {
                    b.OwnsMany("PrjPaniMVCv2.Models.EnderecoModel", "Enderecos", b1 =>
                        {
                            b1.Property<int>("IdUsuario")
                                .HasColumnType("integer");

                            b1.Property<int>("IdEndereco")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("IdEndereco"));

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnType("char(9)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("char(2)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Referencia")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<bool>("Selecionado")
                                .HasColumnType("boolean");

                            b1.HasKey("IdUsuario", "IdEndereco");

                            b1.ToTable("Endereco");

                            b1.WithOwner()
                                .HasForeignKey("IdUsuario");
                        });

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
