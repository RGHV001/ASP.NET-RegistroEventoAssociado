using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [StringLength(3, ErrorMessage = "O DDD deve ter no máximo 3 caracteres.")]
        public string DDD { get; set; } = string.Empty;

        // Propriedade de navegação para Estado (relacionamento)
        [ForeignKey("EstadoId")]
        public Estado? Estado { get; set; }

        // Chave estrangeira para Estado
        [Required(ErrorMessage = "O estado é obrigatório.")]
        public int EstadoId { get; set; }
    }
}
