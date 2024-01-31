using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace PrjPaniMVCv2.Models
{
    [Owned, Table("Motorista")]
    public class MotoristaModel
    {
        [Key]
        public int IdMotorista { get; set; }
        [ForeignKey("IdPedido")]
        public int IdPedido { get; set; }
        public string NomeMotorista { get; set; }
        public string? ApelidoRota { get; set; }
        public string? Turno { get; set; }
        public PedidoModel? Pedido { get; set; }
        public ICollection<PedidoModel>? Pedidos { get; set; }
    }
}
