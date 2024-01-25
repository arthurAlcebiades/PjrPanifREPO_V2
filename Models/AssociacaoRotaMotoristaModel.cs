using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    public class AssociacaoRotaMotoristaModel
    {
        public int IdRota { get; set; }
        [ForeignKey("IdRota")]
        public RotaModel? Rota { get; set; }
        public int IdMotorista { get; set; }
        [ForeignKey("IdMotorista")]
        public MotoristaModel? Motorista { get; set; }

        //public ICollection<RotaModel>? Rotas { get; set; }
    }
}
