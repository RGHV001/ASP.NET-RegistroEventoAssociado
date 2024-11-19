namespace RegistroEventoAssociadov4.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Contato { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}