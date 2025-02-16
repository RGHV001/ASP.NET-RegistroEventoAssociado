using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do evento não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        // Relacionamento com EspacoLocavel
        [Required(ErrorMessage = "O espaço locável é obrigatório.")]
        public int EspacoLocavelId { get; set; }

        [ForeignKey("EspacoLocavelId")]
        public EspacoLocavel EspacoLocavel { get; set; } = null!;

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de início inválida.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O horário de início é obrigatório.")]
        [DataType(DataType.Time, ErrorMessage = "Horário de início inválido.")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "A data de término é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de término inválida.")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O horário de término é obrigatório.")]
        [DataType(DataType.Time, ErrorMessage = "Horário de término inválido.")]
        public TimeSpan HoraFim { get; set; }

        // Relacionamento com Associado (Responsável)
        [Required(ErrorMessage = "O responsável é obrigatório.")]
        public int ResponsavelId { get; set; }

        [ForeignKey("ResponsavelId")]
        public Associado Responsavel { get; set; } = null!;

        // Lista de convidados do evento
        public List<Convidado> Convidados { get; set; } = new List<Convidado>();

        [Required(ErrorMessage = "O valor da locação é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor da locação deve ser um número positivo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorLocacao { get; set; }
    }
}
