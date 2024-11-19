using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Dependente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do dependente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string CPF { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O RG deve ter no máximo 20 caracteres.")]
        public string RG { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [StringLength(50, ErrorMessage = "O tipo de vínculo não pode exceder 50 caracteres.")]
        public string TipoVinculo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sócio titular é obrigatório.")]
        public int SocioTitularId { get; set; }

        // Propriedade de navegação para o sócio titular
        public Associado? SocioTitular { get; set; }
    }
}
