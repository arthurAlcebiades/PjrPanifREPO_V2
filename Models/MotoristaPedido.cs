using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    public class MotoristaPedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMotorista { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public PedidoModel? Pedidos { get; set; }
        [ForeignKey("IdMotorista")]
        public MotoristaModel? Motoristas { get; set; }  
    }
}
