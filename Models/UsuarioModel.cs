using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPaniMVCv2.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required, MaxLength(128)]
        public string Nome { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }

        public string? Senha { get; set; }
        [ReadOnly(true)]
        public DateTime? DataCadastro { get; }
    }
}
