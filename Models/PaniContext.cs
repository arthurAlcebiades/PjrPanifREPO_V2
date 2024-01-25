using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    public class PaniContext : DbContext
    {
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ItemPedidoModel> ItensPedidos { get; set; }
        public DbSet<RotaModel> Rotas { get; set; }
        public DbSet<MotoristaModel> Motoristas { get; set; }

        public PaniContext(DbContextOptions<PaniContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoModel>().ToTable("Produto");
            modelBuilder.Entity<ClienteModel>()
                .OwnsMany(c => c.Enderecos, e =>
                {
                    e.WithOwner().HasForeignKey("IdUsuario");
                    e.HasKey("IdUsuario", "IdEndereco");
                });
            /*modelBuilder.Entity<AssociacaoRotaMotoristaModel>()
                .HasKey(a => new { a.IdRota, a.IdMotorista });
            modelBuilder.Entity<AssociacaoRotaMotoristaModel>()
            .HasOne(a => a.Rota)
            .WithMany(r => r.Motoristas)
            .HasForeignKey(a => a.IdRota);
            modelBuilder.Entity<AssociacaoRotaMotoristaModel>()
                .HasOne(a => a.Motorista)
                .WithMany(m => m.Rota.IdRota)
                .HasForeignKey(a => a.IdMotorista);
            modelBuilder.Entity<EnderecoModel>()
                .HasOne(e => e.Rota)
                .WithMany(r => r.Enderecos)
                .HasForeignKey(e => e.Rota.IdRota);*/
            modelBuilder.Entity<UsuarioModel>().Property(u => u.DataCadastro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP::date")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<PedidoModel>() 
                .OwnsOne(p => p.EnderecoEntrega, e =>
                {
                    e.Ignore(e => e.IdEndereco);
                    e.Ignore(e => e.Selecionado);
                    e.ToTable("Pedido");
                });
            modelBuilder.Entity<ItemPedidoModel>()
                 .HasKey(ip => new { ip.IdPedido, ip.IdProduto });
        }
    }
}
