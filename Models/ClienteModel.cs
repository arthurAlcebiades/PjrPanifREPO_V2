using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    [Table("Cliente")]
    public class ClienteModel : UsuarioModel
    {
        [Required, Column(TypeName = "char(14)")]
        public string CPF_CNPJ { get; set; }
        [Required, Column(TypeName = "char(11)")]
        public string TelefoneContatoCliente { get; set; }

        public ICollection<EnderecoModel> Enderecos { get; set; }

        public ICollection<PedidoModel> Pedidos { get; set; }
    }
}
