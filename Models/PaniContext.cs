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
        public DbSet<MotoristaPedido> MotoristasPedidos { get; set; }

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
            modelBuilder.Entity<MotoristaModel>().HasMany(m => m.Pedidos).WithOne(p => p.Motorista).HasForeignKey(p => p.IdMotorista);
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
            modelBuilder.Entity<MotoristaPedido>()
                 .HasKey(mp => new { mp.IdPedido, mp.IdMotorista });
        }
    }
}
