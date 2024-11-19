namespace RegistroEventoAssociadov4.Models
{
    public class Associado
    {
        public int Id { get; set; }
        public string NomeTitular { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string CPF { get; set; }
        public string RegistroGeral { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoDeAssociacao { get; set; }
    }
}