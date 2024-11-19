using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do estado é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A sigla do estado é obrigatória.")]
        [StringLength(2, ErrorMessage = "A sigla deve ter no máximo 2 caracteres.")]
        public string Sigla { get; set; } = string.Empty;

        // Relacionamento: um estado pode ter várias cidades
        public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}
