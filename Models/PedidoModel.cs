using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    [Table("Pedido")]
    public class PedidoModel
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime? DataPedido { get; set; }
        public DateTime? DataInicioRecorrencia { get; set; }

        public DateTime? DataFinalRecorrencia { get; set; }

        public DateTime? DataEntrega { get; set; }
        public string? Observacao { get; set; }

        public double? ValorTotal { get; set; }

        public int IdCliente { get; set; }
        [ForeignKey("Motorista")]
        public int? IdMotorista { get; set; }
        public MotoristaModel? Motorista { get; set; }  
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }

        public EnderecoModel? EnderecoEntrega { get; set; }

        public ICollection<ItemPedidoModel> ItensPedido { get; set; }
        public ICollection<MotoristaPedido>? MotoristaPedidos { get; set; }
        //public ICollection<MotoristaModel>? Motoristas { get; set; }
    }
}
