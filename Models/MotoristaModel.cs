using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    [Table("Motorista")]
    public class MotoristaModel
    {
        [Key]
        public int IdMotorista { get; set; }
        public string NomeMotorista { get; set; }
        
        //public List<RotaModel>? Rotas { get; set; }
    }
}
