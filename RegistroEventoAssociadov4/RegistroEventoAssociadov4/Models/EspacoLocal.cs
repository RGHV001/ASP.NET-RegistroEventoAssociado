using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class EspacoLocavel
    {
        [Key]
        public int Id { get; set; } // Chave primária para identificar o espaço locável.

        [Required(ErrorMessage = "O nome do espaço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do espaço não pode exceder 100 caracteres.")]
        public string NomeEspaco { get; set; } = string.Empty; // Nome do espaço locável.

        [StringLength(50, ErrorMessage = "O tamanho do espaço não pode exceder 50 caracteres.")]
        public string Tamanho { get; set; } = string.Empty; // Dimensão ou área do espaço (opcional).

        [Required(ErrorMessage = "A capacidade de pessoas é obrigatória.")]
        [Range(1, 10000, ErrorMessage = "A capacidade deve ser entre 1 e 10.000.")]
        public int CapacidadePessoas { get; set; } // Capacidade máxima de pessoas permitidas no espaço.

        [Required(ErrorMessage = "A data de construção é obrigatória.")]
        public DateTime DataConstrucao { get; set; } // Data em que o espaço foi construído.

        [Required(ErrorMessage = "É necessário informar se o espaço é locável.")]
        public bool Localvel { get; set; } // Indica se o espaço está disponível para locação (true/false).
    }
}
