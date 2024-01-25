using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    [Table("Rota")]
    public class RotaModel
    {
        [Key]
        public int IdRota { get; set; }
        public string ApelidoRota { get; set; }

        //public ICollection<AssociacaoRotaMotoristaModel>? Motoristas { get; set; }
        //public ICollection<EnderecoModel> Enderecos { get; set; }
    }
}
