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
    [Migration("20240120210733_Versao2")]
    partial class Versao2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
#pragma warning restore 612, 618
        }
    }
}