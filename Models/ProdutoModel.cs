using System.ComponentModel.DataAnnotations;

namespace PrjPaniMVCv2.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }

        [Required, MaxLength(128)]
        public string NomeProduto { get; set; }

        public string TipoUnidade { get; set; }

        public double Preco { get; set; }
    }
}
