using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500)]
        public string Descricao { get; set; } = string.Empty;

        // Chave estrangeira para EspacoLocavel
        public int EspacoLocavelId { get; set; }
        [ForeignKey("EspacoLocavelId")]
        public EspacoLocavel EspacoLocavel { get; set; } = null!;

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public TimeSpan HoraFim { get; set; }

        // Chave estrangeira para Associado
        public int ResponsavelId { get; set; }
        [ForeignKey("ResponsavelId")]
        public Associado Responsavel { get; set; } = null!;

        public List<Convidado> Convidados { get; set; } = new List<Convidado>();

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorLocacao { get; set; }
    }
}
