using System.ComponentModel.DataAnnotations;

namespace RegistroEventoAssociadov4.Models
{
    public class Convidado
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RegistroGeral { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Evento { get; set; }
    }
}