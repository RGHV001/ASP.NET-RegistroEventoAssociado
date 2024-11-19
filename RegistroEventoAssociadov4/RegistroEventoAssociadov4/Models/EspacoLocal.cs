using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class EspacoLocavel
    {
        [Key]
        public int Id { get; set; }
        public string NomeEspaco { get; set; }
        public string Tamanho { get; set; }
        public int CapacidadePessoas { get; set; }
        public DateTime DataConstrucao { get; set; }
        public bool Localvel { get; set; }
    }
}